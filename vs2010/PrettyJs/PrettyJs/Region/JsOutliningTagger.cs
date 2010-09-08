using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Outlining;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace Jrt.PrettyJs {

    /// <summary>
    /// 
    /// </summary>
    internal sealed class JavascriptCoderTagger : ITagger<IOutliningRegionTag> {

        #region Static Fields /////////////////////////////////////////////////////////////////////

        static readonly RegexOptions RegexOptions =
            RegexOptions.Compiled |
            RegexOptions.CultureInvariant |
            RegexOptions.IgnoreCase |
            RegexOptions.IgnorePatternWhitespace |
            RegexOptions.Singleline;

        static readonly string BlockBeginPattern = @"(?<text>^.*)(?:\s*\{)";
        static readonly string BlockEndPattern = @"(?:\})";
        static readonly string CustomBeginPattern = @"((?://\s*\#\#)|(?://\s*\#\>))(?<text>.*)";
        static readonly string CustomEndPattern = @"(?://\s*\#end)|(?://\s*\#\<)";

        static readonly string CommentStartPattern = @"(?<code>.*?)(?<comment>/\*|//)(.*)";
        static readonly string CommentEndPattern = @"(.*)(?<comment>\*/)(?<code>.*)";
        static readonly string CommentAllPattern = @"(.*?)/\*(.*?)\*/(?<code>.*)";
        

        #endregion
        
        #region Fields  ///////////////////////////////////////////////////////////////////////////

        ITextBuffer _buffer;
        List<Region> _regions;
        ITextSnapshot _snapshot;

        #endregion

        #region Properties  ///////////////////////////////////////////////////////////////////////

        Regex BlockBegin { get; set; }
        Regex BlockEnd { get; set; }
        Regex CustomBegin { get; set; }
        Regex CustomEnd { get; set; }
        Regex CommentStart { get; set; }
        Regex CommentEnd { get; set; }
        #endregion

        #region Events ////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Occurs when [tags changed].
        /// </summary>
        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        #endregion

        #region Construct /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="JavascriptCoderTagger"/> class.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        public JavascriptCoderTagger(ITextBuffer buffer) {
            _buffer = buffer;
            _snapshot = buffer.CurrentSnapshot;
            _regions = new List<Region>();
            _buffer.Changed += OnBufferChanged;

            BlockBegin = new Regex(BlockBeginPattern, RegexOptions);
            BlockEnd = new Regex(BlockEndPattern, RegexOptions);
            CustomBegin = new Regex(CustomBeginPattern, RegexOptions);
            CustomEnd = new Regex(CustomEndPattern, RegexOptions);

            CommentStart = new Regex(CommentStartPattern, RegexOptions);
            CommentEnd = new Regex(CommentEndPattern, RegexOptions);

            this.Refactor();
        }
        #endregion

        #region Methods ///////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <param name="spans">The spans.</param>
        /// <returns></returns>
        public IEnumerable<ITagSpan<IOutliningRegionTag>> GetTags(NormalizedSnapshotSpanCollection spans) {

            if (spans.Count == 0) yield break;

            List<Region> currentRegions = _regions;
            ITextSnapshot currentSnapshot = _snapshot;
            SnapshotSpan entire = new SnapshotSpan(spans[0].Start, spans[spans.Count - 1].End)
                .TranslateTo(currentSnapshot, SpanTrackingMode.EdgeExclusive);
            int startLineNumber = entire.Start.GetContainingLine().LineNumber;
            int endLineNumber = entire.End.GetContainingLine().LineNumber;

            foreach (var region in currentRegions) {
                if (region.StartLine <= endLineNumber && region.EndLine >= startLineNumber) {
                    yield return region.AsOutliningRegionTag();
                }
            }

        }

        /// <summary>
        /// Called when [buffer changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Microsoft.VisualStudio.Text.TextContentChangedEventArgs"/> instance containing the event data.</param>
        void OnBufferChanged(object sender, TextContentChangedEventArgs e) {
            // If this isn't the most up-to-date version of the buffer, 
            // then ignore it for now (we'll eventually get another change event).
            if (e.After != _buffer.CurrentSnapshot) return;
            this.Refactor();
        }

        /// <summary>
        /// Refactors the specified spans.
        /// </summary>
        /// <param name="spans">The spans.</param>
        void Refactor() {
            
            ITextSnapshot newSnapshot = _buffer.CurrentSnapshot;
            List<Region> newRegions = new List<Region>();
            Match match;
            Region region;
            Stack<Region> stack = new Stack<Region>();
            bool lastComment = false;

            Func<string, string> parser = null;


            parser = (string text) =>
            {
                if (lastComment == false)
                {
                    if (CommentStart.IsMatch(text))
                    {
                        match = CommentStart.Match(text);
                        if (match.Groups["comment"].Value == "/*")
                        {
                            lastComment = true;
                        }
                        text = match.Groups["code"].Value;
                        return parser(text);
                    }
                }
                else
                {
                    if (CommentEnd.IsMatch(text))
                    {
                        match = CommentEnd.Match(text);
                        lastComment = false;
                        text = match.Groups["code"].Value;
                        return parser(text);
                    }
                }
                return text;
            };

            foreach (var line in newSnapshot.Lines) {
                string text = line.GetText();
                string originalText = text;
                bool isComment = lastComment;
                text = parser(text);
                
                //if (lastComment == false )
                //{
                //    if (CommentStart.IsMatch(text))
                //    {
                //        match = CommentStart.Match(text);
                //        if (match.Groups["comment"].Value == "/*")
                //        {
                //            isComment = true;
                //        }
                //        text = match.Groups["code"].Value;
                //    }
                //}
                //else
                //{
                //    if (CommentEnd.IsMatch(text))
                //    {
                //        match = CommentEnd.Match(text);
                //        isComment = false;
                //        text = match.Groups["code"].Value;
                //    }
                //}
                if (!isComment)
                {
                    if (BlockBegin.IsMatch(text))
                    {
                        if (text.IndexOf('}') == -1)
                        {
                            match = BlockBegin.Match(text);
                            stack.Push(new Region
                            {
                                Start = line.Start,
                                StartLine = line.LineNumber,
                                Text = match.Groups["text"].Value,
                                Type = RegionType.Block
                            });
                        }
                    }
                    else if (BlockEnd.IsMatch(text))
                    {
                        if ((text.IndexOf('{') == -1) && (stack.Count > 0))
                        {
                            region = stack.Peek();
                            if (region.Type == RegionType.Block) stack.Pop();
                            region.End = line.End;
                            region.EndLine = line.LineNumber;
                            newRegions.Add(region);
                        }
                    }
                }

                if (CustomBegin.IsMatch(originalText))
                {
                    match = CustomBegin.Match(originalText);
                    stack.Push(new Region
                    {
                        Start = line.Start,
                        StartOffset = originalText.IndexOf(match.Groups["text"].Value),
                        StartLine = line.LineNumber,
                        Text = match.Groups["text"].Value,
                        Type = RegionType.Custom
                    });
                }
                else if (CustomEnd.IsMatch(originalText))
                {
                    if ((stack.Count > 0))
                    {
                        region = stack.Peek();
                        if (region.Type == RegionType.Custom) stack.Pop();
                        region.End = line.End;
                        region.EndLine = line.LineNumber;
                        newRegions.Add(region);
                    }
                }
            }

            //determine the changed span, and send a changed event with the new spans
            List<Span> oldSpans =
                new List<Span>(_regions.Select(r =>
                    r.AsSnapshotSpan()
                    .TranslateTo(newSnapshot, SpanTrackingMode.EdgeExclusive)
                    .Span));
            List<Span> newSpans =
                    new List<Span>(newRegions.Select(r => r.AsSnapshotSpan().Span));

            NormalizedSpanCollection oldSpanCollection = new NormalizedSpanCollection(oldSpans);
            NormalizedSpanCollection newSpanCollection = new NormalizedSpanCollection(newSpans);
            //the changed regions are regions that appear in one set or the other, but not both.
            NormalizedSpanCollection removed = NormalizedSpanCollection.Difference(oldSpanCollection, newSpanCollection);

            int changeStart = int.MaxValue;
            int changeEnd = -1;

            if (removed.Count > 0) {
                changeStart = removed[0].Start;
                changeEnd = removed[removed.Count - 1].End;
            }

            if (newSpans.Count > 0) {
                changeStart = Math.Min(changeStart, newSpans[0].Start);
                changeEnd = Math.Max(changeEnd, newSpans[newSpans.Count - 1].End);
            }

            _snapshot = newSnapshot;
            _regions = newRegions;

            if (changeStart <= changeEnd) {
                ITextSnapshot snap = _snapshot;
                if (this.TagsChanged != null)
                    this.TagsChanged(this, new SnapshotSpanEventArgs(
                        new SnapshotSpan(_snapshot, Span.FromBounds(changeStart, changeEnd))));
            }

        }
        #endregion
    }

    public class CommentParserResult
    {
        public bool isComment;
        public string code;
    }
}

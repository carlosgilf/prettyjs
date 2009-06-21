#region Disclaimer/Info
/*
 * PrettyJs  - http://jintan.cnblogs.com
 * Copyright (c) ½ùÈçÌ¹.  All rights reserved.
 * 
 * The contents of this file are subject to the Mozilla Public
 * License Version 1.1 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of
 * the License at http://www.mozilla.org/MPL/
 * 
 * Software distributed under the License is distributed on an 
 * "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or
 * implied. See the License for the specific language governing
 * rights and limitations under the License.
 */
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.CommandBars;
using EnvDTE80;
using EnvDTE;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;

namespace JrtCoder
{
    /// <summary>
    /// Wrapped useful functions to speed up my Add-In development
    /// </summary>
    public class UsefulFunctions
    {
        private DTE2 _applicationObject;
        private AddIn _addInInstance;

        public UsefulFunctions(DTE2 applicationObject, AddIn addInInstance)
        {
            _applicationObject = applicationObject;
            _addInInstance = addInInstance;
        }

        public CommandBar GetCommandBar(string key, CommandBar itemCmbBar)
        {
            string[] keys = key.Split('.');

            if (itemCmbBar == null)
                itemCmbBar = ((CommandBars)_applicationObject.CommandBars)[keys[0]];
            else
            {
                CommandBarControl toolsControl = itemCmbBar.Controls[key[0]];
                CommandBarPopup toolsPopup = (CommandBarPopup)toolsControl;

                itemCmbBar = toolsPopup.CommandBar;
            }


            if (itemCmbBar != null)
            {
                if (keys.Length == 1)
                {
                    return itemCmbBar;
                }
                else
                {
                    string newKey = key.Substring(key.IndexOf('.') + 1);
                    return GetCommandBar(newKey, itemCmbBar);
                }
            }

            return null;
        }

        public IDesignerHost GetActiveDesigner()
        {
            if (_applicationObject.ActiveDocument != null)
            {
                foreach (Window W in _applicationObject.ActiveDocument.Windows)
                {
                    IDesignerHost Host = W.Object as IDesignerHost;
                    if (Host != null)
                        return Host;
                }
            }

            return null;
        }

        public Control GetFirstActiveControl()
        {
            IDesignerHost host = GetActiveDesigner();
            if (host != null)
            {
                ISelectionService sel = (ISelectionService)
                    host.GetService(Type.GetType("System.ComponentModel.Design.ISelectionService,System"));

                if (sel.PrimarySelection is Control)
                    return sel.PrimarySelection as Control;
            }

            return null;
        }

        public ICollection SelectedControls()
        {
            IDesignerHost host = GetActiveDesigner();
            if (host != null)
            {
                ISelectionService sel = (ISelectionService)
                    host.GetService(Type.GetType("System.ComponentModel.Design.ISelectionService,System"));

                return sel.GetSelectedComponents();
            }

            return null;
        }

        public Control AddControlToForm(Type controlType)
        {
            IDesignerHost host = GetActiveDesigner();
            if (host == null)
                return null;

            using (DesignerTransaction Transaction = host.CreateTransaction("DevSource 'control browser' add-in - add control to form"))
            {
                IComponent newComponent =
                   host.CreateComponent(controlType);

                Control newControl = newComponent as Control;
                if (newControl != null)
                {
                    newControl.Parent = host.RootComponent as Control;
                    //newControl.Text = Text != null ? Text : newControl.Name;
                    newControl.BringToFront();
                }

                Transaction.Commit();
                return newControl;
            }
        }



        public void CreateNewTextFile(string content)
        {
            _applicationObject.ItemOperations.NewFile("General\\Text File", "", "");

            TextDocument().Selection.Insert(content, 0);
        }

        public string TextRead()
        {
            return TextDocument().Selection.Text;
        }

        public void TextWrite(string toWrite)
        {
            TextDocument().Selection.Text = toWrite;
        }

        public TextDocument TextDocument()
        {
            return (TextDocument)_applicationObject.ActiveDocument.Object("TextDocument");
        }
    }
}
<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!--Drag and drop templates-->
  <xsl:template match="Tags.Row[../@Attr.View='Details']" mode="modDragged">
    <div>
      <xsl:call-template name="tplSetToolTip" />
      <nobr>
        <xsl:if test="@Attr.Image">
          <img class="Common-Icon16X16" align="absmiddle" src="{@Attr.Image}" />
        </xsl:if>
      <span class="ListView-FontData" style="vertical-align:middle;">
         <xsl:value-of select="@c0" />
      </span></nobr>    
      </div>
  </xsl:template>
  
  <!--Rows templates--> 
  <xsl:template name="tplListViewDrawDetailsRows">
    <xsl:param name="prmCols" />
    <xsl:param name="prmRows" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmGridLines" />
    
    <div dir="{$dir}" vwgfocuselement="1" tabindex="-1" vwgscrollable="1" data-scrollable="yes" onscroll="mobjApp.Controls_StoreScroll(window,'{@Id}',this);mobjApp.Web_SyncScroll(this,mobjApp.Web_GetElementById('HEADER_{@Id}',window),1,'{$dir}')" onresize="mobjApp.Web_SyncScrollSchedule(this,mobjApp.Web_GetElementById('HEADER_{@Id}',window),1,'{$dir}');">
      <xsl:if test="not(@Attr.Enabled='0')">
        <xsl:attribute name="onkeydown">mobjApp.ListView_KeyDown('<xsl:value-of select="@Id" />',window,event);</xsl:attribute>
      </xsl:if>
      <xsl:attribute name="style">
        width:100%;height:100%;
        <xsl:if test="not (@Attr.Scrollbars)">overflow:auto;</xsl:if>
        <xsl:if test="@Attr.Scrollbars='0'">overflow:hidden;</xsl:if>
      </xsl:attribute>
      <xsl:call-template name="tplRestoreScroll" />
      <table style="table-layout:fixed;" BORDER="0" CELLSPACING="0" CELLPADDING="0" width="100%">
        <xsl:if test="@Attr.GridLines='1'">
          <xsl:attribute name="class">ListView-GridLines</xsl:attribute>
        </xsl:if>
        <xsl:if test="$prmCheckBoxes='1'">
          <col width="22" class="ListView-Column" />
          <col width="[Skin.HeaderSeperatorWidth]px" class="ListView-ColumnSeperator" />
        </xsl:if>
        <xsl:for-each select="$prmCols">
          <col id="COL2_{@Id}" width="{@W}">
            <xsl:attribute name="class">
              ListView-Column <xsl:if test="@Attr.Sort='1' or @Attr.Sort='0'">ListView-SortedColumn</xsl:if>
            </xsl:attribute>
          </col>
          <col width="[Skin.HeaderSeperatorWidth]px" class="ListView-ColumnSeperator" />
        </xsl:for-each>
        <col />
        <xsl:choose>
          <xsl:when test="(count($prmRows) &gt; 0)">
				          
			  <xsl:for-each select="$prmRows">
              <xsl:call-template name="tplDrawDetailsRow">
                <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes" />
                <xsl:with-param name="prmCols" select="$prmCols" />
                
              </xsl:call-template>
				
            </xsl:for-each>
          </xsl:when>
          <xsl:otherwise>
            <tr>
              <!-- Count item Columns and seperator columns-->
              <td colspan="{count($prmCols)*2}">
                <div> </div>
              </td>
            </tr>
          </xsl:otherwise>
        </xsl:choose>
      </table>
    </div>
  </xsl:template>

  <xsl:template name="tplListViewDrawListRows">
    <xsl:param name="prmCheckBoxes" />
    <xsl:for-each select="Tags.Row | Tags.Group">
      <xsl:if test="name()='Tags.Group'">
        <div style="clear:both;">
          <xsl:call-template name="tplDrawGroupHeader" />
        </div>
      </xsl:if>
      <xsl:if test="not(name()='Tags.Group')">
        <div id="VWG_{@Id}" tabindex="-1" vwgevents="{@Attr.Events}" vwgfocuselement="1" style="direction:{$dir};">
          <xsl:call-template name="tplApplyDragAndDrop" />
          <xsl:attribute name="class">
            Common-HideFocus ListView-FontData ListView-ListItem
            <xsl:if test="@Attr.Selected='1'"> ListView-ListItem_Selected</xsl:if>
          </xsl:attribute>
          <div class="Common-HandCursor" style="white-space:nowrap; direction:{$dir};display:inline;" dir="{$dir}">
            <xsl:call-template name="tplApplyListViewItemClickEvents" />
            <xsl:call-template name="tplSetToolTip" />
            <xsl:if test="$prmCheckBoxes='1'">
              <span>
                <xsl:if test="not(../@Attr.Enabled='0') and not(@Attr.Enabled='0')">
                  <xsl:attribute name="onclick">
                    mobjApp.ListView_CheckBoxClick('<xsl:value-of select="../@Id" />','<xsl:value-of select="@Id" />',window,event)
                  </xsl:attribute>                  
                </xsl:if>
                <xsl:if test="../@Attr.Enabled='0' or @Attr.Enabled='0'">
                  <xsl:attribute name="disabled">true</xsl:attribute>
                </xsl:if>
                <img id="LVI_CB_{@Id}" class="ListView-CheckBoxImage" align="absmiddle">
                  <xsl:choose>
                    <xsl:when test="@Attr.Checked='1'">
                      <xsl:attribute name="src">[Skin.Path]CheckBox1.gif.wgx</xsl:attribute>
                    </xsl:when>
                    <xsl:otherwise>
                      <xsl:attribute name="src">[Skin.Path]CheckBox0.gif.wgx</xsl:attribute>
                    </xsl:otherwise>
                  </xsl:choose>
                </img>
              </span>
              <span> </span>
            </xsl:if>
            <img class="Common-Icon16X16" align="absmiddle" src="{@Attr.Image}">
              <xsl:if test="not(@Attr.Image)">
                <xsl:attribute name="style">visibility:hidden;</xsl:attribute>
              </xsl:if>
            </img>
            <span class="ListView-ListItemLabel">
              <xsl:attribute name="style">vertical-align:middle;<xsl:value-of select="@s0" /></xsl:attribute>
               <xsl:value-of select="@c0" />
            </span>
          </div>
        </div>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="tplListViewDrawSmallIconsRows">
    <xsl:param name="prmCheckBoxes" />
    <xsl:for-each select="Tags.Row | Tags.Group">
      <xsl:if test="name()='Tags.Group'">
        <div style="clear:both;">
          <xsl:call-template name="tplDrawGroupHeader" />
        </div>
      </xsl:if>
      <xsl:if test="not(name()='Tags.Group')">
        <div id="VWG_{@Id}" tabindex="-1" vwgevents="{@Attr.Events}" vwgfocuselement="1">
          <xsl:call-template name="tplApplyDragAndDrop" />
          <xsl:call-template name="tplSetToolTip" />
          <xsl:attribute name="style">
            float:<xsl:value-of select="$left" />;
            direction:<xsl:value-of select="$dir" />;
          </xsl:attribute>
          <xsl:attribute name="class">
            Common-HideFocus Common-HandCursor ListView-ListSmallItem
            <xsl:if test="@Attr.Selected='1'"> ListView-ListSmallItem_Selected</xsl:if>
          </xsl:attribute>
          <nobr dir="{$dir}">
            <xsl:if test="$prmCheckBoxes='1'">
              <!-- CheckBox Icon (Image) -->
              <img id="LVI_CB_{@Id}" class="ListView-CheckBoxImage" align="absmiddle">
                <xsl:if test="not(../@Attr.Enabled='0') and not(@Attr.Enabled='0')">
                  <xsl:attribute name="onclick">
                    mobjApp.ListView_CheckBoxClick('<xsl:value-of select="../@Id" />','<xsl:value-of select="@Id" />',window,event)
                  </xsl:attribute>
                </xsl:if>
                <xsl:if test="../@Attr.Enabled='0' or @Attr.Enabled='0'">
                  <xsl:attribute name="disabled">true</xsl:attribute>
                </xsl:if>
                <xsl:choose>
                  <xsl:when test="@Attr.Checked='1'">
                    <xsl:attribute name="src">[Skin.Path]CheckBox1.gif.wgx</xsl:attribute>
                  </xsl:when>
                  <xsl:otherwise>
                    <xsl:attribute name="src">[Skin.Path]CheckBox0.gif.wgx</xsl:attribute>
                  </xsl:otherwise>
                </xsl:choose>
              </img>
            </xsl:if>
            <!-- Icon (Image) of the item -->
            <img class="ListView-ListSmallItemImage" src="{@Attr.Image}" align="absmiddle">
              <!-- Applying OnClick and OnDblClick JS actions for Icon click -->
              <xsl:call-template name="tplApplyListViewItemClickEvents" />

              <!-- Applying image size in style or putting default value -->
              <xsl:attribute name="style">
                <xsl:choose>
                  <xsl:when test="../@Attr.ImageWidth">
                    width:<xsl:value-of select="../@Attr.ImageWidth" />px;
                  </xsl:when>
                  <xsl:otherwise>
                    width:16px;
                  </xsl:otherwise>
                </xsl:choose>
                <xsl:choose>
                  <xsl:when test="../@Attr.ImageHeight">
                    height:<xsl:value-of select="../@Attr.ImageHeight" />px;
                  </xsl:when>
                  <xsl:otherwise>
                    height:16px;
                  </xsl:otherwise>
                </xsl:choose>
                <xsl:if test="not(@Attr.Image)">visibility:hidden;</xsl:if>
              </xsl:attribute>
            </img>
            <span class="ListView-SmallItemLabel ListView-FontData">
             <xsl:attribute name="style"><xsl:value-of select="@s0" /></xsl:attribute>
              <xsl:call-template name="tplApplyListViewItemClickEvents" />
              <xsl:value-of select="@c0" />
              <xsl:if test="not(@c0) or @c0=''"> </xsl:if>
            </span>
          </nobr>
        </div>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="tplListViewDrawLargeIconsRows">
    <xsl:param name="prmCheckBoxes" />
    <xsl:for-each select="Tags.Row | Tags.Group">
      <xsl:if test="name()='Tags.Group'">
        <div style="clear:both;">
          <xsl:call-template name="tplDrawGroupHeader" />
        </div>
      </xsl:if>
      <xsl:if test="not(name()='Tags.Group')">
        <div id="VWG_{@Id}" tabindex="-1" vwgevents="{@Attr.Events}" vwgfocuselement="1">
          <xsl:attribute name="style">
            float: <xsl:value-of select="$left" />; display:table-cell; vertical-align:middle;
            <xsl:choose>
              <xsl:when test="../@Attr.LargeImageWidth and number(../@Attr.LargeImageWidth)&gt;100">
                width:<xsl:value-of select="number(../@Attr.LargeImageWidth)+30" />px;
              </xsl:when>
              <xsl:otherwise>
                width:100px;
              </xsl:otherwise>
            </xsl:choose>
          </xsl:attribute>
          <xsl:call-template name="tplSetToolTip" />
          <xsl:call-template name="tplApplyDragAndDrop" />
          <xsl:attribute name="class">
            Common-HideFocus ListView-FontData Common-HandCursor ListView-ListLargeItem
            <xsl:if test="@Attr.Selected='1'"> ListView-ListLargeItem_Selected</xsl:if>
          </xsl:attribute>
          <table cellpadding="0" cellspacing="2" style="width:100%;">
            <tr>
              <td>
                <table style="width:100%;" cellpadding="0" cellspacing="0" align="center" dir="{$dir}">
                  <tr>
                    <!-- TD of CheckBox-->
                    <xsl:if test="$prmCheckBoxes='1'">
                      <!-- TD of CheckBox -->
                      <td width="14" valign="bottom">
                        <xsl:if test="not(../@Attr.Enabled='0') and not(@Attr.Enabled='0')">
                          <xsl:attribute name="onclick">
                            mobjApp.ListView_CheckBoxClick('<xsl:value-of select="../@Id" />','<xsl:value-of select="@Id" />',window,event)
                          </xsl:attribute>
                        </xsl:if>
                        <xsl:if test="../@Attr.Enabled='0' or @Attr.Enabled='0'">
                          <xsl:attribute name="disabled">true</xsl:attribute>
                        </xsl:if>
                        <img id="LVI_CB_{@Id}" class="ListView-CheckBoxImage">
                          <xsl:choose>
                            <xsl:when test="@Attr.Checked='1'">
                              <xsl:attribute name="src">[Skin.Path]CheckBox1.gif.wgx</xsl:attribute>
                            </xsl:when>
                            <xsl:otherwise>
                              <xsl:attribute name="src">[Skin.Path]CheckBox0.gif.wgx</xsl:attribute>
                            </xsl:otherwise>
                          </xsl:choose>
                        </img>
                      </td>
                    </xsl:if>
                    <!-- TD of Large Icon (Image) -->
                    <td align="center">
                      <img class="ListView-ListLargeItemImage">
                        <xsl:call-template name="tplApplyListViewItemClickEvents" />
                        <xsl:attribute name="style">
                          <xsl:choose>
                            <xsl:when test="../@Attr.LargeImageWidth">
                              width:<xsl:value-of select="../@Attr.LargeImageWidth" />px;
                            </xsl:when>
                            <xsl:otherwise>
                              width:32px;
                            </xsl:otherwise>
                          </xsl:choose>
                          <xsl:choose>
                            <xsl:when test="../@Attr.LargeImageHeight">
                              height:<xsl:value-of select="../@Attr.LargeImageHeight" />px;
                            </xsl:when>
                            <xsl:otherwise>
                              height:32px;
                            </xsl:otherwise>
                          </xsl:choose>
                          <xsl:if test="not(@Attr.LargeImage)">visibility:hidden;</xsl:if>
                        </xsl:attribute>
                        <xsl:if test="@Attr.LargeImage">
                          <xsl:attribute name="src">
                            <xsl:value-of select="@Attr.LargeImage" />
                          </xsl:attribute>
                        </xsl:if>
                      </img>
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
            <tr>
              <!-- TD of the Label Text -->
              <td align="center">
                <xsl:attribute name="style">
                  <xsl:if test="$prmCheckBoxes='1'">
                    padding-<xsl:value-of select="$left" />:14px;
                  </xsl:if>
                </xsl:attribute>
                <div class="ListView-LargeItemLabelHeight">
                  <xsl:call-template name="tplApplyListViewItemClickEvents" />
                  <span class="ListView-LargeItemLabel ListView-FontData">
					          <xsl:attribute name="style"><xsl:value-of select="@s0" /></xsl:attribute>
                    <xsl:value-of select="@c0" />
                    <xsl:if test="not(@c0) or @c0=''"> </xsl:if>
                  </span>
                </div>
              </td>
            </tr>
          </table>
        </div>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

  <!--Details view sub templates-->

  <xsl:template name="tplListViewDrawHeaders">
    <xsl:param name="prmCols" />
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmGridLines" />
    <xsl:variable name="varHeight" select="@Attr.HeaderHeight" />
    <table border="0" cellspacing="0" cellpadding="0" style="height:100%;width:100%;table-layout:fixed">
      <xsl:if test="$prmCheckBoxes='1'">
        <col width="22px" class="ListView-Column" />
        <col width="[Skin.HeaderSeperatorWidth]px" class="ListView-ColumnSeperator" />
      </xsl:if>
      <xsl:for-each select="$prmCols">
        <col id="COL1_{@Id}" width="{@Attr.Width}px">
          <xsl:attribute name="class">
            ListView-Column <xsl:if test="@Attr.Sort='1' or @Attr.Sort='0'">ListView-SortedColumn</xsl:if>
          </xsl:attribute>
        </col>
        <col width="[Skin.HeaderSeperatorWidth]px" class="ListView-ColumnSeperator" />
      </xsl:for-each>
      <col width="17px" />
      <col width="30px" />
      <col />
      <tr>
        <xsl:if test="$prmCheckBoxes='1'">

          <!--<migration-write migration-reason="Variable to count only LV rows.">
            alert(1);
            debugger;
          </migration-write>-->
          
          <td class="ListView-FontData ListView-HeaderCell"><table border="0" cellSpacing="0" cellPadding="0" style="width:100%;height:100%">
              <tr>
                <td align="center" ss="jrt" onclick="mobjApp.ListView_CheckAllClick(this,{@Id},window)">
                  <img id="LVI_CB_ALL_{@Id}"  class="ListView-CheckBoxImage" debug="1" src="[Skin.Path]CheckBox0.gif.wgx">
                    <xsl:attribute name="src">
                      <xsl:choose>
                        <xsl:when test="count(Tags.Row[@Attr.Checked='1'])=@Attr.TickSize">[Skin.Path]CheckBox1.gif.wgx</xsl:when>
                        <xsl:otherwise>[Skin.Path]CheckBox0.gif.wgx</xsl:otherwise>
                      </xsl:choose>
                    </xsl:attribute>

                    <xsl:attribute name="debug">
                      <xsl:value-of select="count(Tags.Row[@Attr.Checked='1'])" />
                    </xsl:attribute>
                  </img>
                </td>
              </tr>
            </table>
          </td>
          <td class="ListView-HeaderSeperator"> 
           <xsl:call-template name="tplDrawEmptyImage">
            <xsl:with-param name="prmImageWidth" select="[Skin.HeaderSeperatorWidth]" />
          </xsl:call-template>
         </td>
        </xsl:if>
        <xsl:for-each select="$prmCols">
          <td id="VWG_{@Id}" onclick="mobjApp.ListView_HeaderClick(this,{@Id})" vwgevents="{@Attr.Events}" class="ListView-FontData Common-HandCursor ListView-HeaderCell" nowrap="" align="{@Attr.ContentAlign}" vwgdragable="1">
            <xsl:if test="not(../@Attr.Enabled='0') and not(../@Attr.HeaderStyle='1')">
              <xsl:call-template name="tplSetHighlight" />
            </xsl:if>
            <div onmousedown="mobjApp.ListView_OrderColumn('{../@Attr.Id}','{@Attr.Id}',window,event)">
              <span>
                <!--Paint Headers font style-->
                <xsl:attribute name="style">
                  <xsl:call-template name="tplApplyFontStyles">
                    <xsl:with-param name="prmTarget" select="../." />
                  </xsl:call-template>
                  <xsl:choose>
                    <xsl:when test="../@Attr.WrapContents='1'">white-space:normal;</xsl:when>
                    <xsl:otherwise>white-space:nowrap;</xsl:otherwise>
                  </xsl:choose>
                </xsl:attribute>
                <xsl:if test="@Attr.Image">
                  <img src="{@Attr.Image}" height="16" width="16" align="absmiddle" /> 
                </xsl:if>
                <xsl:call-template name="tplDecodeTextAsHtml" /> 
                <span>
                  <xsl:if test="@Attr.Sort='1'">
                    <img src="[Skin.Path]HeaderSortAscending.gif.wgx" align="absmiddle" />
                  </xsl:if>
                  <xsl:if test="@Attr.Sort='0'">
                    <img src="[Skin.Path]HeaderSortDescending.gif.wgx" align="absmiddle" />
                  </xsl:if>
                </span>
              </span>
            </div>
          </td>
          <td class="ListView-HeaderSeperator" colid="{@Id}" onmousedown="mobjApp.ListView_Resize(this,window,event)">
          <xsl:call-template name="tplDrawEmptyImage">
            <xsl:with-param name="prmImageWidth" select="[Skin.HeaderSeperatorWidth]" />
          </xsl:call-template>
          </td>
        </xsl:for-each>
        <td class="ListView-HeaderCell"> </td>
        <td class="ListView-HeaderCell" style="border-left:none"> </td>
        <td class="ListView-HeaderCell" style="border-left:none;"> </td>
      </tr>
    </table>
  </xsl:template>


  <xsl:template name="tplDrawDetailsRow">
    <xsl:param name="prmCheckBoxes" />
    <xsl:param name="prmCols" />
	
    <xsl:param name="prmFlagMatchedElement" select="0" />

    <xsl:variable name="varRow" select="." />    
	<!-- Calculate amount of listview rows before this row, module 2, if 0 (or even number) no alternate.-->
	<xsl:variable name="varAlternate" select="(count(preceding-sibling::Tags.Row) mod 2)=0" />
    <xsl:variable name="varHeight" select="../@Attr.ItemHeight" />
    <xsl:variable name="varIsFullRowSelect" select="../@Attr.FullRowSelect='1' or not(../@Attr.FullRowSelect)" />
    <xsl:variable name="varShowHtml" select="../@showHtml='1' or not(../@showHtml)" />
    
    <xsl:if test="name()='Tags.ListViewPanel'">
      <tr>
        <xsl:if test="$prmFlagMatchedElement=1"><xsl:attribute name="vwg_matchedelement">1</xsl:attribute></xsl:if>
        <td class="ListView-PanelCell" colspan="{count($prmCols)*2 + number($prmCheckBoxes='1')*2+1}">     
          <xsl:apply-templates select="$varRow/*" mode="modLayoutItem" />
        </td>
      </tr>
   </xsl:if>
    
    <xsl:if test="name()='Tags.Group'">
      <tr>
        <xsl:if test="$prmFlagMatchedElement=1"><xsl:attribute name="vwg_matchedelement">1</xsl:attribute></xsl:if>
        <td colspan="{count($prmCols)*2 + number($prmCheckBoxes='1')*2+1}">
          <xsl:call-template name="tplDrawGroupHeader" />
        </td>
      </tr>
    </xsl:if>
    <xsl:if test="name()='Tags.Row'">
      <tr tabindex="-1" vwgevents="{@Attr.Events}" vwgfocuselement="1" style="height:{$varHeight}px;" data-swipable="yes">
        <xsl:if test="$prmFlagMatchedElement=1"><xsl:attribute name="vwg_matchedelement">1</xsl:attribute></xsl:if>
        <xsl:call-template name="tplSetToolTip" />
        <xsl:if test="$varIsFullRowSelect">
          <xsl:attribute name="id">VWG_<xsl:value-of select="@Id" /></xsl:attribute>
        </xsl:if>
        <xsl:call-template name="tplApplyDragAndDrop" />
        <xsl:attribute name="class">
          Common-HideFocus ListView-FontData Common-HandCursor
          <xsl:choose>
            <xsl:when test="$varAlternate"> ListView-DataRow0 ListView-DataRow1 </xsl:when>
            <xsl:otherwise> ListView-DataRow0 </xsl:otherwise>
          </xsl:choose>
          ListView-DataRow
          <xsl:if test="@Attr.Selected='1' and $varIsFullRowSelect"> ListView-DataRow_Selected</xsl:if>
        </xsl:attribute>
        <xsl:if test="$prmCheckBoxes='1'">
          <td class="ListView-Cell ListView-DataCell" align="center">
            <xsl:if test="not(../@Attr.Enabled='0') and not(@Attr.Enabled='0')">
              <xsl:attribute name="onclick">
                mobjApp.ListView_CheckBoxClick('<xsl:value-of select="../@Id" />','<xsl:value-of select="@Id" />',window,event)
              </xsl:attribute>
            </xsl:if>
            <xsl:if test="../@Attr.Enabled='0' or @Attr.Enabled='0'">
              <xsl:attribute name="disabled">true</xsl:attribute>
            </xsl:if>
            <img id="LVI_CB_{@Id}" class="ListView-CheckBoxImage">
              <xsl:choose>
                <xsl:when test="@Attr.Checked='1'">
                  <xsl:attribute name="src">[Skin.Path]CheckBox1.gif.wgx</xsl:attribute>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:attribute name="src">[Skin.Path]CheckBox0.gif.wgx</xsl:attribute>
                </xsl:otherwise>
              </xsl:choose>
            </img>
          </td>
          <td class="ListView-Cell ListView-SeperatorCell"><xsl:text> </xsl:text></td>
        </xsl:if>

        <xsl:for-each select="@*[substring(name(),1,1)='c']">
          <xsl:variable name="varValue" select="." />
          <xsl:variable name="varCol" select="$prmCols[@Attr.Name=name($varValue)]" />
          <xsl:variable name="varType" select="$varCol/@Attr.Type" />
          <xsl:variable name="varIsNotFullRowSelect" select="not($varIsFullRowSelect) and position() = 1" />

          
          <xsl:choose>
            <xsl:when test="$varType='Control'">
              <td class="ListView-Cell ListView-ControlCell" onresize="mobjApp.Layout_ContainerResized(this.firstChild);">     
                <div vwgtype="container" style="width:100%; height:{$varHeight}px; overflow:hidden;position:relative;">
                    <xsl:apply-templates select="$varRow/*[@Id=$varValue]" mode="modLayoutItem" />            
                  </div>
              </td>
            </xsl:when>
            <xsl:when test="$varType='Icon'">
              <td class="ListView-Cell ListView-DataCell" align="center">
                <xsl:call-template name="tplApplyListViewItemClickEvents">
                  <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes" />
                  <xsl:with-param name="prmListViewId" select="../../@Id" />
                  <xsl:with-param name="prmListViewItemId" select="../@Id" />
                </xsl:call-template>
                <xsl:call-template name="tplApplyDetailedCellStyle">
                  <xsl:with-param name="prmRow" select="$varRow" />
                </xsl:call-template>
                  
					<xsl:if test=".=''"> </xsl:if>
					<xsl:if test="not(.='')">
						<img class="Common-Icon16X16" src="{.}" />
					</xsl:if>
				  
				  
              </td>
            </xsl:when>
            <xsl:otherwise>
              <td align="{$varCol/@Attr.TextAlign}">
                <xsl:call-template name="tplApplyListViewItemClickEvents">
                  <xsl:with-param name="prmCheckBoxes" select="$prmCheckBoxes" />
                  <xsl:with-param name="prmListViewId" select="../../@Id" />
                  <xsl:with-param name="prmListViewItemId" select="../@Id" />
                </xsl:call-template>
                <xsl:choose>
                  <xsl:when test="../@Attr.Selected='1' and $varIsNotFullRowSelect">
                    <xsl:attribute name="class">ListView-Cell ListView-DataCell ListView-DataCell_Selected</xsl:attribute>
                  </xsl:when>
                  <xsl:otherwise>
                    <xsl:attribute name="class">ListView-Cell ListView-DataCell</xsl:attribute>
                  </xsl:otherwise>
                </xsl:choose>
                <xsl:if test="$varIsNotFullRowSelect">
                  <xsl:attribute name="id">VWG_<xsl:value-of select="../@Id" /></xsl:attribute>
                  <xsl:attribute name="onclick">
                    mobjApp.ListView_Click('<xsl:value-of select="../../@Id" />','<xsl:value-of select="../@Id" />',window,event)
                  </xsl:attribute>
                  <xsl:attribute name="oncontextmenu">
                    mobjApp.ListView_RightClick('<xsl:value-of select="../../@Id" />','<xsl:value-of select="../@Id" />',window,event)
                  </xsl:attribute>
                  <xsl:if test="$prmCheckBoxes='1'">
                    <xsl:attribute name="ondblclick">
                      mobjApp.ListView_DoubleClick('<xsl:value-of select="../../@Id" />','<xsl:value-of select="../@Id" />',window,event)
                    </xsl:attribute>
                  </xsl:if>
                </xsl:if>
                <xsl:call-template name="tplApplyDetailedCellStyle">
                  <xsl:with-param name="prmRow" select="$varRow" />
                </xsl:call-template>
                <div style="direction:{$dir};" dir="{$dir}">
                  <xsl:if test="$dir='RTL'">
                    <xsl:attribute name="class">ListView-FloatRight</xsl:attribute>
                  </xsl:if>
                  <nobr>
                    <xsl:if test="name()='c0' and ../@Attr.Image">
                      <xsl:if test="../@Attr.IdentCount">
                        <xsl:call-template name="tplApplyRowIdentCount">
                          <xsl:with-param name="prmCount" select="../@Attr.IdentCount" />
                        </xsl:call-template>
                      </xsl:if>
                      <img align="absmiddle" class="Common-Icon16X16" src="{../@Attr.Image}" /> 
                    </xsl:if>
                    <xsl:choose>
                      <xsl:when test="$varShowHtml">
                        <!--jrt 支持现实html,这里的判断也可以用test="../../@showHtml='1'" 来判断-->
                        <img src="[Skin.CommonPath]Empty.gif.wgx" onload="$(this).replaceWith($(this).attr('vwgsource'))">
                          <xsl:attribute name="vwgsource">
                            <xsl:value-of select="." /> 
                          </xsl:attribute>
                        </img>
                    </xsl:when>
                      <xsl:otherwise>
                        <xsl:value-of select="." /> 
                      </xsl:otherwise>
                    </xsl:choose>
                  </nobr>
                </div>
              </td>
            </xsl:otherwise>
          </xsl:choose>
          <td class="ListView-Cell ListView-SeperatorCell">
            <xsl:call-template name="tplApplyDetailedCellStyle">
              <xsl:with-param name="prmRow" select="$varRow" />
            </xsl:call-template>
            <xsl:text> </xsl:text>
          </td>
        </xsl:for-each>
        <td class="ListView-Cell ListView-DataCell"> </td>
      </tr>
    </xsl:if>
	</xsl:template>
  
  <!--Matching for controls that serve as panel.-->
  <xsl:template match="Tags.ListViewPanel/*" mode="modLayoutItem">
    <div vwgtype="control">
      <xsl:attribute name="style">
        height:<xsl:value-of select="@H" />px;
        width:100%;
        <xsl:call-template name="tplApplyStyles" />
        <xsl:if test="@Attr.Visible='0'">
          display:none;  
        </xsl:if>
        position:relative;
      </xsl:attribute>
      <xsl:call-template name="tplSetControl" />
      <xsl:if test="not(@Attr.Visible='0')">
        <xsl:apply-templates select="." mode="modContent" />
      </xsl:if>
    </div>
  </xsl:template>
  


  <xsl:template name="tplApplyDetailedCellStyle">
    <xsl:param name="prmRow" />
    <xsl:variable name="varValue" select="." />
    <xsl:choose>
      <xsl:when test="../@Attr.UseItemStyleForSubItems = '1'">
        <xsl:variable name="varItemStyle" select="$prmRow/@*[name()='s0']" />
        <xsl:call-template name="tplSetCellStyle">
          <xsl:with-param name="prmStyle" select="$varItemStyle" />
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <xsl:variable name="varSubItemStyle" select="$prmRow/@*[name()=concat('s',substring(name($varValue),2))]" />
        <xsl:call-template name="tplSetCellStyle">
          <xsl:with-param name="prmStyle" select="$varSubItemStyle" />
        </xsl:call-template>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  
  <xsl:template name="tplSetCellStyle">
    <xsl:param name="prmStyle" />
    <xsl:attribute name="style"><xsl:value-of select="$prmStyle" /></xsl:attribute>
  </xsl:template>

  <xsl:template name="tplApplyRowIdentCount">
    <xsl:param name="prmCount" />
    <img align="absmiddle" class="Common-Icon16X16" style="visibility:hidden;" />
    <xsl:if test="$prmCount &gt; 1">
      <xsl:call-template name="tplApplyRowIdentCount">
        <xsl:with-param name="prmCount" select="$prmCount - 1" />  
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplApplyListViewItemClickEvents">
    <xsl:param name="prmListViewId" select="../@Id" />
    <xsl:param name="prmListViewItemId" select="@Id" />
    <xsl:param name="prmCheckBoxes" select="../@Attr.CheckBoxes" />

    <xsl:if test="not(../@Attr.Enabled='0')">
      <xsl:attribute name="onclick">
        mobjApp.ListView_Click('<xsl:value-of select="$prmListViewId" />','<xsl:value-of select="$prmListViewItemId" />',window,event)
      </xsl:attribute>
      <xsl:attribute name="oncontextmenu">
        mobjApp.ListView_RightClick('<xsl:value-of select="$prmListViewId" />','<xsl:value-of select="$prmListViewItemId" />',window,event)
      </xsl:attribute>
      <xsl:if test="$prmCheckBoxes='1'">
        <xsl:attribute name="ondblclick">
          mobjApp.ListView_DoubleClick('<xsl:value-of select="$prmListViewId" />','<xsl:value-of select="$prmListViewItemId" />',window,event)
        </xsl:attribute>
      </xsl:if>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplDrawGroupHeader">
    <table class="ListView-FontGroupHeader" cellpadding="0" cellspacing="0" width="100%">
      <tr>
        <td class="ListView-FontGroupHeaderLabel">
          <nobr><xsl:call-template name="tplDecodeTextAsHtml" /></nobr>
        </td>
        <td width="100%">
          <div class="ListView-FontGroupHeaderSeperator"> </div>
        </td>
        <td>
          <img>
            <xsl:choose>
              <xsl:when test="not(@Attr.Expanded='0')">
                <xsl:attribute name="src">[Skin.Path]GroupHeaderExpanded.gif.wgx</xsl:attribute>
              </xsl:when>
              <xsl:otherwise>
                <xsl:attribute name="src">[Skin.Path]GroupHeaderCollapsed.gif.wgx</xsl:attribute>
              </xsl:otherwise>
            </xsl:choose>
          </img>
        </td>
      </tr>    
    </table>
  </xsl:template>

  <!--Listview paging template-->
  <xsl:template name="tplDrawListViewPaging">
    <xsl:call-template name="tplDrawPaging">
      <xsl:with-param name="prmID" select="@Attr.Id" />
      <xsl:with-param name="prmCurrentPage" select="@Attr.CurrentPage" />
      <xsl:with-param name="prmTotalPages" select="@Attr.TotalPages" />
      <xsl:with-param name="prmTotalItems" select="@Attr.TickSize"/>
      <xsl:with-param name="prmPageSize" select="@Attr.DisplayYearMonth"/>
      <xsl:with-param name="prmPagingBoxClass" select="'ListView-Control ListView-FontData'"/>
      

      <xsl:with-param name="prmPagingFirstImageWidth" select="'ListView-PagingFirstImageWidth'" />
      <xsl:with-param name="prmPagingFirstButtonClass" select="'ListView-PagingFirstButtonStyle'" />
      <xsl:with-param name="prmPagingPreviousImageWidth" select="'ListView-PagingPreviousImageWidth'" />
      <xsl:with-param name="prmPagingPrevButtonClass" select="'ListView-PagingPrevButtonStyle'" />
      <xsl:with-param name="prmPagingBoxWidth" select="[Skin.PagingBoxWidth]" />
      <xsl:with-param name="prmPagingStatusBoxClass" select="'ListView-PagingStatusBox'" />
      <xsl:with-param name="prmPagingNextImageWidth" select="'ListView-PagingNextImageWidth'" />
      <xsl:with-param name="prmPagingNextButtonClass" select="'ListView-PagingNextButtonStyle'" />
      <xsl:with-param name="prmPagingLastImageWidth" select="'ListView-PagingLastImageWidth'" />
      <xsl:with-param name="prmPagingLastButtonClass" select="'ListView-PagingLastButtonStyle'" />
    </xsl:call-template>
    
  </xsl:template>
</xsl:stylesheet>

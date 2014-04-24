<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <!-- Top level standard form -->
  <xsl:template match="WG:Tags.Form[not(@Inline='1') and not(@Attr.CustomStyle)]">
    <xsl:call-template name="tplWriteFormBodyWithClass" />
  </xsl:template>

  <!-- None top level form -->
  <xsl:template match="WC:Tags.Form" mode="modContent">
    <xsl:if test="@Attr.Enabled='0'"><xsl:attribute name="class">Form-DialogBody Common-InheritDisabled</xsl:attribute></xsl:if>
    <xsl:if test="not(@Attr.Enabled='0')"><xsl:attribute name="class">Form-DialogBody</xsl:attribute></xsl:if>
    <xsl:call-template name="tplDrawContained" />
  </xsl:template>

  <!--Match for a form content in popup mode-->
  <xsl:template match="WG:Tags.Form[@Attr.Type='PopupWindow' and not(@Attr.CustomStyle)]" mode="modFrameCenterContent">
    <xsl:call-template name="tplWriteFormBodyWithClass" />
  </xsl:template>

  <!--Match for a form which is displayed whithin a popup window-->
  <xsl:template match="WG:Tags.Form[@Attr.Type='PopupWindow' and not(@Attr.CustomStyle)]">

    <xsl:variable name="varFormHeightOffset" select="[Skin.PopupWindowOffsetHeight]" />
    <xsl:variable name="varFormWidthOffset" select="[Skin.PopupWindowOffsetWidth]" />

    <xsl:variable name="varNoBorder">
      <xsl:choose>
        <xsl:when test="not(@NoBorder='no')">0</xsl:when>
        <xsl:otherwise>xx</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>


    <div ttt="{$varNoBorder}" eee="{$varNoBorder+[Skin.LeftPopupWindowFrameWidth]}"  style="height:{number(@Attr.Height)+$varFormHeightOffset}px;width:{number(@Attr.Width)+$varFormWidthOffset}px;">
      <xsl:attribute name="class">
        <xsl:if test="not(@Custom='0')">Form-CustomPopupWindow</xsl:if>
        <xsl:if test="@Custom='0'">Form-PopupWindow</xsl:if>
      </xsl:attribute>


     

      <xsl:call-template name="tplDrawFrame">
        <xsl:with-param name="prmLeftBottomClass" select="'Form-BottomLeft'" />
        <xsl:with-param name="prmLeftClass" select="'Form-Left'" />
        <xsl:with-param name="prmLeftTopClass" select="'Form-TopLeft'" />
        <xsl:with-param name="prmTopClass" select="'Form-Top'" />
        <xsl:with-param name="prmRightTopClass" select="'Form-TopRight'" />
        <xsl:with-param name="prmRightClass" select="'Form-Right'" />
        <xsl:with-param name="prmRightBottomClass" select="'Form-BottomRight'" />
        <xsl:with-param name="prmBottomClass" select="'Form-Bottom'" />
        <xsl:with-param name="prmCenterClass" select="'Form-Center'" />
        <xsl:with-param name="prmCenterContent" select="." />

        <xsl:with-param name="prmIsActiveFrame" select="1" />


        <xsl:with-param name="prmLeftFrameWidth" select="$varNoBorder+[Skin.LeftPopupWindowFrameWidth]" />
        <xsl:with-param name="prmRightFrameWidth" select="$varNoBorder+[Skin.RightPopupWindowFrameWidth]" />
        <xsl:with-param name="prmTopFrameHeight" select="$varNoBorder+[Skin.TopPopupWindowFrameHeight]" />
        <xsl:with-param name="prmBottomFrameHeight" select="$varNoBorder+[Skin.BottomPopupWindowFrameHeight]" />
      </xsl:call-template>
    </div>
  </xsl:template>

  <!--Match for form's control box-->
  <xsl:template match="WG:Tags.FormControlBox" name="tplDrawFormControlBox">

    <!--Attribute value variables-->
    <xsl:variable name="varShowMaximizeBox" select="@Attr.Maximize='1'" />
    <xsl:variable name="varShowMinimizeBox" select="@Attr.Minimize='1'" />
    <xsl:variable name="varFormBorderStyle" select="@Attr.FormBorderStyle" />
    <xsl:variable name="varWindowState" select="@Attr.WindowState" />

    <!--Classes variables-->
    <xsl:variable name="varMinimizeBoxClass">
      <xsl:choose>
        <xsl:when test="$varWindowState='1'">Form-RestoreButton</xsl:when>
        <xsl:otherwise>Form-MinimizeButton</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varMinimizeBoxDisabledClass">
      <xsl:choose>
        <xsl:when test="$varWindowState='1'">Form-RestoreButton Form-RestoreButton_Disabled</xsl:when>
        <xsl:otherwise>Form-MinimizeButton Form-MinimizeButton_Disabled</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varMaximizeBoxClass">
      <xsl:choose>
        <xsl:when test="$varWindowState='2'">Form-RestoreButton</xsl:when>
        <xsl:otherwise>Form-MaximizeButton</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varMaximizeBoxDisabledClass">
      <xsl:choose>
        <xsl:when test="$varWindowState='2'">Form-RestoreButton Form-RestoreButton_Disabled</xsl:when>
        <xsl:otherwise>Form-MaximizeButton Form-MaximizeButton_Disabled</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <!--Tooltip variables-->
    <xsl:variable name="varMinimizeBoxTitle">
      <xsl:choose>
        <xsl:when test="$varWindowState='1'">Labels.WindowRestoreUp</xsl:when>
        <xsl:otherwise>Labels.WindowMinimize</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varMaximizeBoxTitle">
      <xsl:choose>
        <xsl:when test="$varWindowState='2'">Labels.WindowRestoreDown</xsl:when>
        <xsl:otherwise>Labels.WindowMaximize</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>


    <table id="VWGE_WinHeader{@Attr.Id}" class="Form-HeaderPart Form-HeaderButtons" dir="{$dir}" border="0" cellpadding="0" cellspacing="0" style="{$right}:0px;table-layout:auto;" onmousedown="Popups_HidePopups(); Web_EventCancelBubble(event);">
      <tr>
        <xsl:if test="($varShowMaximizeBox or $varShowMinimizeBox) and ($varFormBorderStyle &lt; 5 and not($varFormBorderStyle=0))">
          <td>
              <div id="VWGE_WinMinimize{@Attr.Id}" style="overflow:hidden">
              <xsl:if test="$varShowMinimizeBox">
                <xsl:attribute name="onclick">mobjApp.Forms_MinimizeInlineWindow(<xsl:value-of select="@Attr.Id" />,window,true)</xsl:attribute>
                <xsl:attribute name="class"><xsl:value-of select="concat('Common-HandCursor ',$varMinimizeBoxClass)" /></xsl:attribute>
                <xsl:attribute name="title"><xsl:value-of select="$varMinimizeBoxTitle" /></xsl:attribute>
                <xsl:call-template name="tplSetHighlight" />
              </xsl:if>
              <xsl:if test="not($varShowMinimizeBox)">
                <xsl:attribute name="class"><xsl:value-of select="concat('Common-HandCursor ',$varMinimizeBoxDisabledClass)" /></xsl:attribute>
              </xsl:if>
              <xsl:call-template name="tplDrawEmptyImage">
                <xsl:with-param name="prmFillContainer" select="'1'" />
                <xsl:with-param name="prmPositionStyle" select="'absolute'" />
              </xsl:call-template>
            </div>
          </td>
          <td>
            <div id="VWGE_WinMaximize{@Attr.Id}" style="overflow:hidden">
                <xsl:if test="$varShowMaximizeBox">
                  <xsl:attribute name="onclick">mobjApp.Forms_MaximizeInlineWindow(<xsl:value-of select="@Attr.Id" />,event,window,true,true)</xsl:attribute>
                  <xsl:attribute name="class"><xsl:value-of select="concat('Common-HandCursor ',$varMaximizeBoxClass)" /></xsl:attribute>
                  <xsl:attribute name="title"><xsl:value-of select="$varMaximizeBoxTitle" /></xsl:attribute>
                  <xsl:call-template name="tplSetHighlight" />
              </xsl:if>
                <xsl:if test="not($varShowMaximizeBox)">
                  <xsl:attribute name="class"><xsl:value-of select="concat('Common-HandCursor ',$varMaximizeBoxDisabledClass)" /></xsl:attribute>
                </xsl:if>
              <xsl:call-template name="tplDrawEmptyImage">
                <xsl:with-param name="prmFillContainer" select="'1'" />
                <xsl:with-param name="prmPositionStyle" select="'absolute'" />
              </xsl:call-template>
            </div>
          </td>
        </xsl:if>
        <td>
          <div id="VWGE_WinClose{@Attr.Id}" class="Common-HandCursor Form-CloseButton" style="overflow:hidden" onclick="Forms_CloseInlineWindow({@Attr.Id},event,window)" title="Labels.WindowClose">
            <xsl:call-template name="tplSetHighlight" />
            <xsl:call-template name="tplDrawEmptyImage">
              <xsl:with-param name="prmFillContainer" select="'1'" />
              <xsl:with-param name="prmPositionStyle" select="'absolute'" />
            </xsl:call-template>
          </div>
        </td>
      </tr>
      <tr>
        <td colspan="3" class="Form-BoxesBarFooter"></td>
      </tr>
    </table>
  </xsl:template>

  <!-- Top level inline modaless form -->
  <xsl:template match="WG:Tags.Form[(not(@Attr.Type='MainWindow') and @Inline='1') or @Attr.Mashup='1']">
    <xsl:call-template name="tplWriteFormContainer" />
  </xsl:template>

  <!-- Writes the form body with in the frame center -->
  <xsl:template match="WG:Tags.Form" mode="modFrameCenterContent">
    <xsl:call-template name="tplWriteFormBodyWithClass" />
  </xsl:template>

  <!-- Writes the form header with in the frame header -->
  <xsl:template match="WG:Tags.Form" mode="modFrameHeaderContent">
    <xsl:variable name="varResizable" select="@Attr.Resize='1'" />
    <xsl:variable name="varLeftFrameWidth" select="[Skin.LeftDialogWindowFrameWidth]" />
    <xsl:variable name="varRightFrameWidth" select="[Skin.RightDialogWindowFrameWidth]" />
    <xsl:variable name="varDialogFrame" select="@Attr.FormBorderStyle &lt; 5 and not(@Attr.FormBorderStyle=0)" />
    <xsl:variable name="varToolFrame" select="@Attr.FormBorderStyle &gt; 4" />
    <xsl:variable name="varFormHeaderClass">
      <xsl:choose>
        <xsl:when test="$varDialogFrame">Form-Header Form-DialogHeader</xsl:when>
        <xsl:when test="$varToolFrame">Form-Header Form-ToolHeader</xsl:when>
        <xsl:otherwise>Form-Header</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <div id="VWGE_WinHeaderContainer{@Attr.Id}" class="Common-MoveCursor Common-Unselectable" style="position:static;width:100%;height:100%;">
      <xsl:attribute name="vwgdrag">m</xsl:attribute>
      <xsl:attribute name="onmousedown">mobjApp.Forms_DragInlineWindow(<xsl:value-of select="@Attr.Id" />,true,this,window,event);Forms_BringWindowToTop(<xsl:value-of select="@Attr.Id" />);</xsl:attribute>

      <xsl:call-template name="tplDrawEmptyImage">
        <xsl:with-param name="prmFillContainer" select="'1'" />
        <xsl:with-param name="prmPositionStyle" select="'absolute'" />
      </xsl:call-template>

      <xsl:if test="not($varResizable) and $varLeftFrameWidth &gt; 0">
        <div style="position:absolute;width:{$varLeftFrameWidth}px;height:100%;left:{-1*number($varLeftFrameWidth)};top:0px;"> </div>
      </xsl:if>
      <div class="{$varFormHeaderClass}" cellpadding="0" cellspasing="0" border="0">

        <!-- Writes the form header caption -->
        <div class="Form-HeaderPart Form-HeaderCaption" dir="{$dir}" style="{$left}:0px;">
          <xsl:if test="@Attr.Icon">
            <img id="VWGE_WinHeaderIcon{@Attr.Id}" src="{@Attr.Icon}" class="Form-Icon" />
            <xsl:text> </xsl:text>
          </xsl:if>
          <nobr id="VWGE_WinTX{@Id}">
            <xsl:call-template name="tplDecodeTextAsHtml" />
          </nobr>
        </div>
        <xsl:call-template name="tplDrawFormControlBox" />
      </div>
      <xsl:if test="not($varResizable) and $varRightFrameWidth &gt; 0">
        <div style="position:absolute;width:{$varRightFrameWidth}px;height:100%;right:{-1*number($varRightFrameWidth)};top:0px;"> </div>
      </xsl:if>
    </div>
  </xsl:template>

  <!--Call the tplWriteFormBody template inorder to write form body with a proper class name-->
  <xsl:template name="tplWriteFormBodyWithClass">
    <xsl:call-template name="tplWriteFormBody">
      <xsl:with-param name="prmClassName">
        <xsl:if test="@Attr.Style='0'">Common-DefaultCursor Form-DialogBody</xsl:if>
        <xsl:if test="@Attr.Style='1'">Common-DefaultCursor Form-WindowBody</xsl:if>
      </xsl:with-param>
    </xsl:call-template>
  </xsl:template>

  <!-- Creates the form container -->
  <xsl:template name="tplWriteFormContainer">
    <xsl:variable name="varResizable" select="@Attr.Resize='1'" />
    <xsl:variable name="varDialogFrame" select="@Attr.FormBorderStyle &lt; 5 and not(@Attr.FormBorderStyle=0)" />
    <xsl:variable name="varToolFrame" select="@Attr.FormBorderStyle &gt; 4" />
    <xsl:variable name="varNoFrame" select="@Attr.FormBorderStyle=0" />

    <!-- Calculate the form height and width offset -->
    <xsl:variable name="varDialogHeightOffset" select="[Skin.TopDialogWindowFrameHeight]+[Skin.BottomDialogWindowFrameHeight]" />
    <xsl:variable name="varDialogWidthOffset" select="[Skin.LeftDialogWindowFrameWidth]+[Skin.RightDialogWindowFrameWidth]" />
    <xsl:variable name="varToolHeightOffset" select="[Skin.TopToolWindowFrameHeight]+[Skin.BottomToolWindowFrameHeight]" />
    <xsl:variable name="varToolWidthOffset" select="[Skin.LeftToolWindowFrameWidth]+[Skin.RightToolWindowFrameWidth]" />
    <xsl:variable name="varFormHeightOffset" select="0 + number($varDialogFrame)*$varDialogHeightOffset + number($varToolFrame)*$varToolHeightOffset" />
    <xsl:variable name="varFormWidthOffset" select="0 + number($varDialogFrame)*$varDialogWidthOffset + number($varToolFrame)*$varToolWidthOffset" />

    <!-- Calculate the handler attribute -->
    <xsl:variable name="varResizeHandlerAttribute">
      <xsl:if test="$varResizable">
        <xsl:value-of select="concat('Forms_DragInlineWindow(' , @Id , ',' , $varResizable , ',this,window,event);')" />
      </xsl:if>
    </xsl:variable>

    <div id="WRP_{@Id}" vwgdragable="1" vwgresizable="1" vwginlinewindow="1" vwgguid="{@Id}" vwgmdiparent="{@Attr.MdiParent}" onmousedown="Forms_BringWindowToTop({@Id});" style="position:absolute;float:left;left:{@L}px;top:{@T}px;height:{number(@H)+$varFormHeightOffset}px;width:{number(@W)+$varFormWidthOffset}px;">

      <!-- FormBorderStyle = Sizable, FixedDialog, Fixed3D, FixedSingle-->
      <xsl:if test="$varDialogFrame">
        <xsl:attribute name="class">Form-Window Form-DialogWindow</xsl:attribute>
        <xsl:call-template name="tplDrawFrame">
          <xsl:with-param name="prmLeftBottomClass" select="'Form-BottomLeft'" />
          <xsl:with-param name="prmLeftClass" select="'Form-Left'" />
          <xsl:with-param name="prmLeftTopClass" select="'Form-TopLeft'" />
          <xsl:with-param name="prmTopClass" select="'Form-Top'" />
          <xsl:with-param name="prmRightTopClass" select="'Form-TopRight'" />
          <xsl:with-param name="prmRightClass" select="'Form-Right'" />
          <xsl:with-param name="prmRightBottomClass" select="'Form-BottomRight'" />
          <xsl:with-param name="prmBottomClass" select="'Form-Bottom'" />
          <xsl:with-param name="prmCenterClass" select="'Form-Center'" />
          <xsl:with-param name="prmRightOverlayClass" select="'Form-RightOverlay'" />
          <xsl:with-param name="prmLeftOverlayClass" select="'Form-LeftOverlay'" />
          <xsl:with-param name="prmCenterContent" select="." />
          <xsl:with-param name="prmHeaderContent" select="." />
          <xsl:with-param name="prmResizeHandler" select="$varResizeHandlerAttribute" />

          <xsl:with-param name="prmIsActiveFrame" select="1" />

          <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftDialogWindowFrameWidth]" />
          <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightDialogWindowFrameWidth]" />
          <xsl:with-param name="prmTopFrameHeight" select="[Skin.TopDialogWindowFrameHeight]" />
          <xsl:with-param name="prmBottomFrameHeight" select="[Skin.BottomDialogWindowFrameHeight]" />
        </xsl:call-template>
      </xsl:if>

      <!-- FormBorderStyle = FixedToolWindow, SizableToolWindow-->
      <xsl:if test="$varToolFrame">
        <xsl:attribute name="class">Form-Window Form-ToolWindow</xsl:attribute>
        <xsl:call-template name="tplDrawFrame">
          <xsl:with-param name="prmLeftBottomClass" select="'Form-BottomLeft'" />
          <xsl:with-param name="prmLeftClass" select="'Form-Left'" />
          <xsl:with-param name="prmLeftTopClass" select="'Form-TopLeft'" />
          <xsl:with-param name="prmTopClass" select="'Form-Top'" />
          <xsl:with-param name="prmRightTopClass" select="'Form-TopRight'" />
          <xsl:with-param name="prmRightClass" select="'Form-Right'" />
          <xsl:with-param name="prmRightBottomClass" select="'Form-BottomRight'" />
          <xsl:with-param name="prmBottomClass" select="'Form-Bottom'" />
          <xsl:with-param name="prmCenterClass" select="'Form-Center'" />
          <xsl:with-param name="prmCenterContent" select="." />
          <xsl:with-param name="prmHeaderContent" select="." />
          <xsl:with-param name="prmResizeHandler" select="$varResizeHandlerAttribute" />

          <xsl:with-param name="prmIsActiveFrame" select="1" />

          <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftToolWindowFrameWidth]" />
          <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightToolWindowFrameWidth]" />
          <xsl:with-param name="prmTopFrameHeight" select="[Skin.TopToolWindowFrameHeight]" />
          <xsl:with-param name="prmBottomFrameHeight" select="[Skin.BottomToolWindowFrameHeight]" />
        </xsl:call-template>
      </xsl:if>

      <!-- FormBorderStyle = None-->
      <xsl:if test="$varNoFrame">
        <xsl:attribute name="class">Form-Window</xsl:attribute>
        <xsl:apply-templates select="." mode="modFrameCenterContent" />
      </xsl:if>
    </div>
  </xsl:template>

</xsl:stylesheet>
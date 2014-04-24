<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">


  <xsl:template match="WC:Tags.ToolBarButton" mode="modButtonContent">
            
     <xsl:if test="not(@Attr.Enabled = '0')">
      <xsl:attribute name="class">Common-HandCursor ToolBarButton-Control </xsl:attribute>
     </xsl:if>
     <xsl:if test="@Attr.Enabled = '0'">    
      <xsl:attribute name="class">Common-HandCursor ToolBarButton-Control Common-Disabled</xsl:attribute>
     </xsl:if>
      <xsl:if test="@Attr.Pushed='1'">
        <xsl:call-template name="tplDrawFrame">
          <xsl:with-param name="prmContentClass" select="'ToolBarButton-Content'" />
          <xsl:with-param name="prmFrameClass" select="'ToolBarButton-Frame'" />
          <xsl:with-param name="prmLeftBottomClass" select="'ToolBarButton-PushedBottomLeft'" />
          <xsl:with-param name="prmLeftClass" select="'ToolBarButton-PushedLeft'" />
          <xsl:with-param name="prmLeftTopClass" select="'ToolBarButton-PushedTopLeft'" />
          <xsl:with-param name="prmTopClass" select="'ToolBarButton-PushedTop'" />
          <xsl:with-param name="prmRightTopClass" select="'ToolBarButton-PushedTopRight'" />
          <xsl:with-param name="prmRightClass" select="'ToolBarButton-PushedRight'" />
          <xsl:with-param name="prmRightBottomClass" select="'ToolBarButton-PushedBottomRight'" />
          <xsl:with-param name="prmBottomClass" select="'ToolBarButton-PushedBottom'" />
          <xsl:with-param name="prmCenterClass" select="'ToolBarButton-PushedCenter'" />
          <xsl:with-param name="prmCenterContent" select="." />

          <xsl:with-param name="prmIsAutoSize" select="1" />

          <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]" />
          <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
          <xsl:with-param name="prmTopFrameHeight" select="[Skin.TopFrameHeight]" />
          <xsl:with-param name="prmBottomFrameHeight" select="[Skin.BottomFrameHeight]" />

        </xsl:call-template>
      </xsl:if>

      <xsl:if test="not(@Attr.Pushed='1')">
        <xsl:call-template name="tplDrawFrame">
          <xsl:with-param name="prmContentClass" select="'ToolBarButton-Content'" />
          <xsl:with-param name="prmFrameClass" select="'ToolBarButton-Frame'" />
          <xsl:with-param name="prmLeftBottomClass" select="'ToolBarButton-BottomLeft'" />
          <xsl:with-param name="prmLeftClass" select="'ToolBarButton-Left'" />
          <xsl:with-param name="prmLeftTopClass" select="'ToolBarButton-TopLeft'" />
          <xsl:with-param name="prmTopClass" select="'ToolBarButton-Top'" />
          <xsl:with-param name="prmRightTopClass" select="'ToolBarButton-TopRight'" />
          <xsl:with-param name="prmRightClass" select="'ToolBarButton-Right'" />
          <xsl:with-param name="prmRightBottomClass" select="'ToolBarButton-BottomRight'" />
          <xsl:with-param name="prmBottomClass" select="'ToolBarButton-Bottom'" />
          <xsl:with-param name="prmCenterClass" select="'ToolBarButton-Center'" />        
          <xsl:with-param name="prmCenterContent" select="." />

          <xsl:with-param name="prmIsAutoSize" select="1" />

          <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]" />
          <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
          <xsl:with-param name="prmTopFrameHeight" select="[Skin.TopFrameHeight]" />
          <xsl:with-param name="prmBottomFrameHeight" select="[Skin.BottomFrameHeight]" />
          
        </xsl:call-template>
      </xsl:if>
  </xsl:template>
  
  <xsl:template match="WC:Tags.ToolBarButton" mode="modFrameCenterContent">
    <xsl:variable name="varText">
      <xsl:if test="@Attr.Text"><xsl:value-of select="@Attr.Text" /></xsl:if> 
      <xsl:if test="../@Attr.TextImageRelation=1 and $varWinFormsCompatible =1">
        <xsl:if test="(not(@Attr.Text) or @Attr.Text='') and count(../WC:Tags.ToolBarButton[(@Attr.Text and not(@Attr.Text=''))]) &gt; 0"> </xsl:if>
      </xsl:if>
    </xsl:variable>

    <!--jrt: dynimic change text align-->
    <xsl:variable name="varTextAlign">
      <xsl:choose>
        <xsl:when test="../@Attr.TextImageRelation=1">
          <xsl:value-of select="'CenterMiddle'" />
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="'LeftMiddle'" />
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    
    
    <xsl:call-template name="tplDrawButtonContent">
      <xsl:with-param name="prmText" select="$varText" />
      <xsl:with-param name="prmTextClass" select="'ToolBarButton-FontData'" />
      <xsl:with-param name="prmTextAlign" select="$varTextAlign" />
      <xsl:with-param name="prmImageAlign" select="'CenterMiddle'" />
      <xsl:with-param name="prmImageHeight" select="../@Attr.ImageHeight" />
      <xsl:with-param name="prmImageWidth" select="../@Attr.ImageWidth" />
      <xsl:with-param name="prmTextImageRelation" select="../@Attr.TextImageRelation" />
      <xsl:with-param name="prmLayoutPadding" select="0" />
      <xsl:with-param name="prmDropDown" select="@Attr.DropDown" />
      <xsl:with-param name="prmDropDownWidth" select="[Skin.DropDownImageWidth]" />
      <xsl:with-param name="prmDropDownClass" select="'ToolBarButton-DropDown'" />
    </xsl:call-template>
  </xsl:template>
  
  <xsl:template match="WC:Tags.ToolBarButton" mode="modContent">
    <xsl:choose>
      <xsl:when test="@Attr.Icon='#Before' or @Attr.Icon='#Space' or @Attr.Icon='#After'">
      </xsl:when>
      <xsl:when test="@Attr.Style='3'">
        <div style="float:{$dir};height:100%;position:relative" class="ToolBarButton-Seperator">
          <dd />
        </div>
      </xsl:when>
      <xsl:otherwise>
        <div style="width:100%;height:100%;position:relative">
          <xsl:if test="not(@Attr.Enabled='0') and not(../@Attr.Enabled='0') and not(@Attr.CustomStyle='Label')">
            <xsl:call-template name="tplSetHighlight" />
          </xsl:if>
          <xsl:apply-templates select="." mode="modButtonContent" />
        </div>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  
</xsl:stylesheet>

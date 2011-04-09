<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <!-- Applies common button attributes -->
  <xsl:template name="tplApplyButtonAttributesTButton">
    <xsl:param name="prmButtonClass" />

    <!-- If button is disabled -->
    <xsl:if test="@Attr.Enabled='0'">
      <xsl:attribute name="class">
        <xsl:value-of select="concat('Common-Unselectable ',$prmButtonClass,' ',$prmButtonClass,'_Disabled')"/>
      </xsl:attribute>
    </xsl:if>

    <!-- If button is enabled -->
    <xsl:if test="not(@Attr.Enabled='0')">
      <xsl:attribute name="class">
        <xsl:value-of select="concat('Common-HandCursor Common-Unselectable ',$prmButtonClass)"/>
      </xsl:attribute>
      <xsl:attribute name="onkeydown">
        mobjApp.Button_KeyPress('<xsl:value-of select="@Attr.Id" />',event);
      </xsl:attribute>
      <xsl:attribute name="onmouseover">
        mobjApp.Button_MouseOver('<xsl:value-of select="@Attr.Id" />',event);
      </xsl:attribute>
      <xsl:call-template name="tplSetHighlight" />
      <xsl:call-template name="tplSetFocusable" />
    </xsl:if>
  </xsl:template>

  <!--Main API for drawing control-->
  <xsl:template name="tplDrawButtonAPITButton">
    <!--Template parameters-->
    <xsl:param name="prmButtonClass" select="'Button-Control'" />
    <xsl:param name="prmLeftBottomClass" select="'Button-BottomLeft'" />
    <xsl:param name="prmLeftClass" select="'Button-Left'" />
    <xsl:param name="prmLeftTopClass" select="'Button-TopLeft'" />
    <xsl:param name="prmTopClass" select="'Button-Top'" />
    <xsl:param name="prmRightTopClass" select="'Button-TopRight'" />
    <xsl:param name="prmRightClass" select="'Button-Right'" />
    <xsl:param name="prmRightBottomClass" select="'Button-BottomRight'" />
    <xsl:param name="prmBottomClass" select="'Button-Bottom'" />
    <xsl:param name="prmFontDataClass" select="'Button-FontData'" />
    <xsl:param name="prmCenterClass" select="'Button-Center'" />
    <xsl:param name="prmCenterTransparentClass" select="'Button-CenterTransparent'" />
    <xsl:param name="prmContentClass" select="'Button-Content'" />

    <!-- Apply button attributes -->
    <xsl:call-template name="tplApplyButtonAttributesTButton" >
      <xsl:with-param name="prmButtonClass" select="$prmButtonClass" />
    </xsl:call-template>

    <!-- Draw button frame -->
    <xsl:call-template name="tplDrawFrame">
      <xsl:with-param name="prmLeftBottomClass" select="$prmLeftBottomClass"/>
      <xsl:with-param name="prmLeftClass" select="$prmLeftClass"/>
      <xsl:with-param name="prmLeftTopClass" select="$prmLeftTopClass"/>
      <xsl:with-param name="prmTopClass" select="$prmTopClass"/>
      <xsl:with-param name="prmRightTopClass" select="$prmRightTopClass"/>
      <xsl:with-param name="prmRightClass" select="$prmRightClass"/>
      <xsl:with-param name="prmRightBottomClass" select="$prmRightBottomClass"/>
      <xsl:with-param name="prmBottomClass" select="$prmBottomClass"/>
      <xsl:with-param name="prmCenterClass">
        <xsl:choose>
          <xsl:when test="@Attr.BackgroundImage and (@Attr.BackgroundImageLayout='3' or @Attr.BackgroundImageLayout='4')">
            <xsl:value-of select="concat($prmFontDataClass,' ',$prmCenterTransparentClass)"/>
          </xsl:when>
          <xsl:otherwise>
            <xsl:value-of select="concat($prmFontDataClass,' ',$prmCenterClass)"/>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:with-param>
      <xsl:with-param name="prmContentClass" select="$prmContentClass" />
      <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]"/>
      <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
      <xsl:with-param name="prmTopFrameHeight"  select="[Skin.TopFrameHeight]"/>
      <xsl:with-param name="prmBottomFrameHeight"  select="[Skin.BottomFrameHeight]"/>
      <xsl:with-param name="prmLeftContentOffset" select="0" />
      <xsl:with-param name="prmRightContentOffset" select="0" />
      <xsl:with-param name="prmTopContentOffset" select="0" />
      <xsl:with-param name="prmBottomContentOffset" select="0" />
      <xsl:with-param name="prmCenterContent" select="."/>
    </xsl:call-template>
  </xsl:template>
  
  <xsl:template match="WC:Tags.Button[@Attr.CustomStyle='TButtonSkin']" mode="modContent">
    <xsl:call-template name="tplDrawButtonAPITButton">
      <xsl:with-param name="prmButtonClass" select="'Button-Control'" />
      <xsl:with-param name="prmLeftBottomClass" select="'Button-BottomLeft'" />
      <xsl:with-param name="prmLeftClass" select="'Button-Left'" />
      <xsl:with-param name="prmLeftTopClass" select="'Button-TopLeft'" />
      <xsl:with-param name="prmTopClass" select="'Button-Top'" />
      <xsl:with-param name="prmRightTopClass" select="'Button-TopRight'" />
      <xsl:with-param name="prmRightClass" select="'Button-Right'" />
      <xsl:with-param name="prmRightBottomClass" select="'Button-BottomRight'" />
      <xsl:with-param name="prmBottomClass" select="'Button-Bottom'" />
      <xsl:with-param name="prmFontDataClass" select="'Button-FontData'" />
      <xsl:with-param name="prmCenterClass" select="'Button-Center'" />
      <xsl:with-param name="prmCenterTransparentClass" select="'Button-CenterTransparent'" />
      <xsl:with-param name="prmContentClass" select="'Button-Content'" />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.Button[@Attr.CustomStyle='TButtonSkin']" mode="modFrameCenterContent">
    <xsl:call-template name="tplDrawButtonContentAPI">
      <xsl:with-param name="prmFontDataClass" select="'Button-FontData'"/>
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>

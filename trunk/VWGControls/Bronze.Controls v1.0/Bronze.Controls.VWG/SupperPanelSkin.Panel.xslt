<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The custom style Panel match template -->
  <xsl:template match="WC:Tags.Panel[@Attr.CustomStyle='SupperPanelSkin']" mode="modContent">
    <xsl:call-template name="tplDrawNewPanelAPI" />
  </xsl:template>


  <!-- Main API for drawing the control -->
  <xsl:template name="tplDrawNewPanelAPI">
    <xsl:param name="prmControlClass" select="'Panel-Control'" />
    <xsl:param name="prmControlInitScript" select="''" />

    <xsl:variable name ="hiddenClass" >
      <xsl:choose>
        <xsl:when test="@Hidden='1'">
          <xsl:value-of select="'SupperPanel-Hidden '"/>
        </xsl:when>
        <xsl:when test="@Hidden='2'">
          <xsl:value-of select="'SupperPanel-VHidden '"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="''"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:variable name ="radiusClass" >
      <xsl:choose>
        <xsl:when test="not(@Radius) or @Radius=''">
          <xsl:value-of select="''"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="'SupperPanel-Radius'"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:call-template name="tplDrawPanelAPI">
      <xsl:with-param name="prmControlClass" select="concat($prmControlClass,' ',$hiddenClass,$radiusClass)"/>
    </xsl:call-template>

    <img style="visibility:hidden;height:0;width:0" src="Resources.Gizmox.WebGUI.Forms.Skins.CommonSkin.Empty.gif.wgx" onload="SupperPanel_Init('{@Attr.Id}',this);{$prmControlInitScript}" >
    </img>
  </xsl:template>
  
  
</xsl:stylesheet>

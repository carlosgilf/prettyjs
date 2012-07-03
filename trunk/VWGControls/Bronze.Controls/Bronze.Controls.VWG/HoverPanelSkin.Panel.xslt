<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The custom style Panel match template -->
  <xsl:template match="WC:Tags.Panel[@Attr.CustomStyle='HoverPanelSkin']" mode="modContent">

    <!--<xsl:if test="not(@Attr.Enabled='0') and not(@Overable='0')">

      <img style="visibility:hidden;height:0;width:0" src="[Skin.CommonPath]Empty.gif.wgx" onload="HoverPanel_Init('{@Attr.Id}')">
      </img>
      
    
    </xsl:if>-->

    <xsl:if test="@Hidden='0'">
      <xsl:call-template name="tplDrawPanelAPI">
        <xsl:with-param name="prmControlClass" select="'Panel-Control '"/>
      </xsl:call-template>
    </xsl:if>

    <xsl:if test="not(@Hidden='0')">
      <xsl:call-template name="tplDrawPanelAPI">
        <xsl:with-param name="prmControlClass" select="'Panel-Control HoverPanelHidden'"/>
      </xsl:call-template>
    </xsl:if>
   
   
  </xsl:template>
</xsl:stylesheet>

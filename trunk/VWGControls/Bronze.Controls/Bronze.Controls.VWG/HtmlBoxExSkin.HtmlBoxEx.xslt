<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">
  <xsl:template match="WC:Tags.FrameControl[@Attr.CustomStyle='HtmlBoxEx']" mode="modContent">
    <xsl:if test="@SEL='1'">
      <xsl:attribute name="Class">FrameControl-Control HtmlBoxEx-Selectable</xsl:attribute>
    </xsl:if>
    <xsl:if test="not(@SEL='1')">
      <xsl:attribute name="Class">FrameControl-Control</xsl:attribute>
    </xsl:if>
    
    <xsl:if test="not(@Attr.IsInline='1')">
      <iframe id="TRG_{@Id}" class="FrameControl-Frame" frameborder="0" allowtransparency="true" src="{@Attr.Source}">&#160;</iframe>
    </xsl:if>
    <xsl:if test="@Attr.IsInline='1'">
      <img src="[Skin.CommonPath]Empty.gif.wgx" onload="$(this).replaceWith($(this).attr('vwgsource'))">
        <xsl:attribute name="vwgsource">
          <xsl:call-template name="tplDecodeText">
            <xsl:with-param name="prmText" select="@Attr.Source"/>
          </xsl:call-template>
        </xsl:attribute>
      </img>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>
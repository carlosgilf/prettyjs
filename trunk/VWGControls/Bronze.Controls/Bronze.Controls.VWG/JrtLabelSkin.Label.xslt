<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.Label[@Attr.CustomStyle='JrtLabelSkin']" mode="modContent">
    <xsl:if test="not(@Attr.Enabled='0')">
      <xsl:attribute name="onmouseout">
        JrtLabel_MouseLeave('<xsl:value-of select="@Attr.Id" />',this);
      </xsl:attribute>
      <xsl:attribute name="onmouseover">
        JrtLabel_MouseOver('<xsl:value-of select="@Attr.Id" />',this);
      </xsl:attribute>
    </xsl:if>


    <xsl:call-template name="tplDrawLabelAPI">
      <xsl:with-param name="prmControlClass" select="'Label-Control'">

      </xsl:with-param>
      <xsl:with-param name="prmControlDisabledClass" select="'Label-Disabled'"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="WC:Tags.Label[@Attr.CustomStyle='JrtLabelSkin']" mode="modContentText">
    <xsl:call-template name="tplDrawLabelContentAPI">
      <xsl:with-param name="prmContentContainerClass" select="'Label-ContentContainer'"/>
    </xsl:call-template>
    <!--<xsl:if test="@Attr.AutoEllipsis='1'">-->
      <img style="visibility:hidden;height:0;width:0" src="Resources.Gizmox.WebGUI.Forms.Skins.CommonSkin.Empty.gif.wgx" onload="JrtLabel_Init('{@Attr.Id}',this);" >
      </img>
    <!--</xsl:if>-->
    
  </xsl:template>
 

</xsl:stylesheet>
<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">
  <xsl:template name="SetLabelMouseEvent">
    <xsl:if test="not(@Attr.Enabled='0')">
      <xsl:attribute name="onmouseout">
        JrtLabel_MouseLeave('<xsl:value-of select="@Attr.Id" />',this);
      </xsl:attribute>
      <xsl:attribute name="onmouseover">
        JrtLabel_MouseOver('<xsl:value-of select="@Attr.Id" />',this);
      </xsl:attribute>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>
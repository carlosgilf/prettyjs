﻿<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The custom style Panel match template -->
  <xsl:template match="WC:Tags.Panel[@Attr.CustomStyle='HoverPanelSkin']" mode="modContent">
    <xsl:call-template name="tplDrawNewPanelAPI" />
  </xsl:template>
  
  
</xsl:stylesheet>

<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">
  <xsl:template name="tplMatchPictureBoxNormal" match="WC:IMGPRC" mode="modContent">
    <div id="contanier_{@Attr.Id}">

      <img id="cropbox_{@Attr.Id}" src="{@Attr.Image}" onload="Jcrop_Initialize({@Attr.Id},this,window)"/>

      

    </div>

  </xsl:template>
</xsl:stylesheet>


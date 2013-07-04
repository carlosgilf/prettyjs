<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">
  <xsl:template match="WC:Tags.Panel[@Attr.CustomStyle='SelectorTextBoxSkin']" mode="modContent">
    <a href="javascript:;" name='jrtjrtjrtjrtjr'></a>
      <table class="EmptyMsg" name="tbEmptyMsg">
        <xsl:attribute name="style">
          <xsl:choose>
            <xsl:when test="@ShowEmptyMsg='1'">display:block</xsl:when>
            <xsl:otherwise>
              display:none;
            </xsl:otherwise>
          </xsl:choose>
        </xsl:attribute>
        
        <tr>
          <td style="text-align:center">
            <xsl:value-of select="@Attr.LoadingMessage" ></xsl:value-of>
          </td>
        </tr>
      </table>
 
    
    <img style="visibility:hidden;height:0;width:0" src="Resources.Gizmox.WebGUI.Forms.Skins.CommonSkin.Empty.gif.wgx" onload="selector_Init({@Attr.Id},this);" >
    </img>
  </xsl:template>

  
 
</xsl:stylesheet>

<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">
  <xsl:template name="tplMatchSupperPictureBoxNormal" match="WC:Tags.PictureBox[@Attr.CustomStyle='SupperPictureBox']" mode="modContent">
    <xsl:param name="prmImageSize" select="@Attr.ImageSize"/>

    <xsl:variable name="varImage" select="@Attr.Image"/>
    <xsl:variable name="varControls" select="WC:*"/>


    
    <xsl:attribute name="class">
        <xsl:if test="@Radius">
          <xsl:value-of select="'SupperPanel-Radius'"/>
        </xsl:if>
    </xsl:attribute>

   

    <div style="width:100%;height:100%;overflow:hidden;">
      <xsl:if test="$varImage">
        <xsl:choose>
          <xsl:when test="$prmImageSize=1">
            <img src="{$varImage}" style="width:100%;height:100%">
              <xsl:attribute name="onmousedown">mobjApp.Web_EventCancelBubble(event,true,false);</xsl:attribute>
              <xsl:call-template name="SetPIE">
                <xsl:with-param name="applyStyle" select="'width:100%;height:100%;'"></xsl:with-param>
              </xsl:call-template>
            </img>
          </xsl:when>
          <xsl:when test="$prmImageSize=3">
            <table cellpadding="0" cellspacing="0" style="width:100%;height:100%;">
              <tr>
                <td>
                  <xsl:attribute name="style">
                    background-image:url('<xsl:value-of select="$varImage"/>');
                    background-repeat:no-repeat;background-position:center center;width:100%;height:100%
                  </xsl:attribute>
                </td>
              </tr>
            </table>
          </xsl:when>
          <xsl:otherwise>
            <img src="{$varImage}" class="44">
              <xsl:attribute name="onmousedown">mobjApp.Web_EventCancelBubble(event,true,false);</xsl:attribute>


              <xsl:call-template name="SetPIE"></xsl:call-template>
              
            </img>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:if>
      <xsl:if test="$varControls">
        <div class="Common-Strech" style="position:absolute;top:0px;left:0px;">
          <xsl:call-template name="tplDrawContained"/>
        </div>
      </xsl:if>
      <xsl:if test="not($varImage) and not($varControls)">
        <xsl:call-template name="tplDrawEmptyImage"/>
      </xsl:if>
    </div>
  </xsl:template>


  <xsl:template name="SetPIE">
    <xsl:param name="applyStyle" select="''"/>
    <xsl:attribute name="class">
      <xsl:if test="@Radius">
        <xsl:value-of select="'SupperPanel-Radius'"/>
      </xsl:if>
    </xsl:attribute>

    <xsl:attribute name="style">
      <xsl:if test="@Radius">
          <xsl:value-of select="concat($applyStyle,@Radius)"/>
      </xsl:if>
    </xsl:attribute>
  </xsl:template>
  

  <xsl:template match="WC:Tags.PictureBox[@Attr.CustomStyle='SupperPictureBox']" mode="modApplyStyle">
      <xsl:if test="@Radius">
        <xsl:value-of select="@Radius"/>
      </xsl:if>
  </xsl:template>

</xsl:stylesheet>


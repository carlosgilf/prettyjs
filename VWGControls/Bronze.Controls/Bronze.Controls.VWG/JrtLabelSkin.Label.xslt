<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <!-- The default style Label match template -->
  <xsl:template match="WC:Tags.Label[@Attr.CustomStyle='JrtLabelSkin']" mode="modContent">
    <xsl:call-template name="SetLabelMouseEvent"/>
    <xsl:call-template name="tplDrawLabelAPI"/>

  </xsl:template>
  <!-- The Main API for drawing the control -->
  <xsl:template name="tplDrawLabelAPI">
    <xsl:param name="prmControlClass" select="'Label-Control'"/>
    <xsl:param name="prmControlDisabledClass" select="'Label-Disabled'"/>

    <xsl:variable name="varImageAlign" select="@Attr.ImageAlign" />
    <xsl:variable name="varImage" select="@Attr.Image" />

    <!-- Set the control class -->
    <xsl:attribute name="class">
      <xsl:value-of select="$prmControlClass"/>
      <xsl:if test="@Attr.Enabled='0'">
        <xsl:value-of select="concat(' ',$prmControlDisabledClass)"/>
      </xsl:if>
    </xsl:attribute>

    <!-- Render the Label -->
    <div dir="{$dir}">
      <xsl:attribute name="style">
        width:100%;height:100%;
        <xsl:if test="$varImage and not(@ImgPS)">
          background-image:url('<xsl:value-of select="$varImage"/>');
          background-repeat:no-repeat;
          background-position:<xsl:if test="contains($varImageAlign,'Top')">top </xsl:if>
          <xsl:if test="contains($varImageAlign,'Bottom')">bottom </xsl:if>
          <xsl:if test="contains($varImageAlign,'Middle')">center </xsl:if>
          <xsl:if test="contains($varImageAlign,'Left')">
            <xsl:value-of select="$left"/>
          </xsl:if>
          <xsl:if test="contains($varImageAlign,'Right')">
            <xsl:value-of select="$right"/>
          </xsl:if>
          <xsl:if test="contains($varImageAlign,'Center')">center</xsl:if>;
        </xsl:if>
      </xsl:attribute>

      <xsl:call-template name="tplApplyLabelLayout" />
    </div>
  </xsl:template>

  <!-- The default style Label Text match template -->
  <xsl:template match="WC:Tags.Label[@Attr.CustomStyle='JrtLabelSkin']" mode="modContentText">
    <xsl:call-template name="tplDrawLabelAndIconContentAPI"/>
    <img style="visibility:hidden;height:0;width:0"  src="Resources.Gizmox.WebGUI.Forms.Skins.CommonSkin.Empty.gif.wgx" onload="JrtLabel_Init('{@Attr.Id}',this);" >
    </img>
  </xsl:template>

  <!-- The Main API for drawing the control -->
  <xsl:template name="tplDrawLabelAndIconContentAPI" match="WC:Tags.Label" mode="modContentText">
    <xsl:param name="prmText" select="@Attr.Text" />
    <xsl:param name="prmContentClass"/>
    <xsl:param name="prmContentContainerClass" select="'Label-ContentContainer'"/>

    <xsl:param name="prmWrapContents" select="1"/>
    <xsl:param name="prmApplyFontStyles" select="1"/>

    <!-- Render the Label Content-->
    <div class="{$prmContentContainerClass}">
      <xsl:attribute name="style">
        <xsl:call-template name="tplApplyPaddings"/>
      </xsl:attribute>

      <xsl:variable name="varImage" select="@Attr.Image" />
      <xsl:if test="$varImage and @ImgPS">
        <img class="label_icon">
          <xsl:attribute name="style">
            vertical-align:middle;
            <xsl:if  test="@ImgPS='Left' or @ImgPS='Right'">
              margin-right:<xsl:value-of select="@ImgSpace"/>px;
              margin-top: -2px;
            </xsl:if>
            <xsl:if  test="@ImgPS='Bottom'">
              margin-top:<xsl:value-of select="@ImgSpace"/>px;
            </xsl:if>
            <xsl:if  test="@ImgPS='Top' ">
              margin-bottom:<xsl:value-of select="@ImgSpace"/>px;
            </xsl:if>
            
            <xsl:if test="@Attr.ImageWidth">
              width:<xsl:value-of select="@Attr.ImageWidth"/>px;
            </xsl:if>
            <xsl:if test="@Attr.ImageHeight">
              height:<xsl:value-of select="@Attr.ImageHeight"/>px;
            </xsl:if>
          </xsl:attribute>

          <xsl:attribute name="src">
            <xsl:value-of select="$varImage"/>
          </xsl:attribute>

        </img>
      </xsl:if>

      <xsl:call-template name="tplDrawLabelContentElement">
        <xsl:with-param name="prmText" select="$prmText" />
        <xsl:with-param name="prmApplyFontStyles" select="$prmApplyFontStyles"/>
        <xsl:with-param name="prmContentClass" select="$prmContentClass"/>
        <xsl:with-param name="prmWrapContents" select="$prmWrapContents"/>
      </xsl:call-template>
    </div>
  </xsl:template>

  <xsl:template name="tplDrawLabelContentElement">
    <xsl:param name="prmText" select="@Attr.Text" />
    <xsl:param name="prmApplyFontStyles" select="1"/>
    <xsl:param name="prmContentClass"/>
    <xsl:param name="prmWrapContents" select="1"/>

    <xsl:if test="$prmWrapContents='1'">
      <span dir="{$dir}">
        <xsl:call-template name="tplDrawLabelContent">
          <xsl:with-param name="prmText" select="$prmText" />
          <xsl:with-param name="prmApplyFontStyles" select="$prmApplyFontStyles"/>
          <xsl:with-param name="prmContentClass" select="$prmContentClass"/>
        </xsl:call-template>
      </span>
    </xsl:if>
    <xsl:if test="not($prmWrapContents='1')">
      <nobr dir="{$dir}">
        <xsl:call-template name="tplDrawLabelContent">
          <xsl:with-param name="prmText" select="$prmText" />
          <xsl:with-param name="prmApplyFontStyles" select="$prmApplyFontStyles"/>
          <xsl:with-param name="prmContentClass" select="$prmContentClass"/>
        </xsl:call-template>
      </nobr>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplDrawLabelContent">
    <xsl:param name="prmText" select="@Attr.Text" />
    <xsl:param name="prmApplyFontStyles" select="1"/>
    <xsl:param name="prmContentClass"/>

    <xsl:attribute name="Class">
      Common-Unselectable <xsl:if test="$prmContentClass">
        <xsl:value-of select="concat(' ',$prmContentClass)"/>
      </xsl:if>
    </xsl:attribute>
    <xsl:attribute name="style">
      <xsl:if test="$prmApplyFontStyles='1'">
        <xsl:call-template name="tplApplyFontStyles"/>;
      </xsl:if>
      <xsl:call-template name="tplApplyCursorStyle" />;

      <xsl:if test="@Attr.Image and (@ImgPS='Top')">
        display:block;
      </xsl:if>
    </xsl:attribute>
    <xsl:call-template name="tplDecodeTextAsHtml">
      <xsl:with-param name="prmText" select="$prmText" />
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>



<!--<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.Label[@Attr.CustomStyle='JrtLabelSkin']" mode="modContent">
    <xsl:if test="not(@Attr.Enabled='0') and not(@Overable='0')">
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
    -->
<!--<xsl:if test="@Attr.AutoEllipsis='1'">-->
<!--
      <img style="visibility:hidden;height:0;width:0" src="Resources.Gizmox.WebGUI.Forms.Skins.CommonSkin.Empty.gif.wgx" onload="JrtLabel_Init('{@Attr.Id}',this);" >
      </img>
    -->
<!--</xsl:if>-->
<!--
    
  </xsl:template>
 

</xsl:stylesheet>-->
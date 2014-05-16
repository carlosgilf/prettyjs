<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">


  <!-- Apply styles to the current container -->
  <xsl:template name="tplApplyStyles">

    <!-- Conditional parmaters -->
    <xsl:param name="prmBorder" select="1" />
    <xsl:param name="prmBackground" select="1" />
    <xsl:param name="prmFont" select="1" />
    <xsl:param name="prmCursor" select="1" />

    <xsl:if test="$prmBorder='1'">
      <xsl:if test="@Attr.Border">
        <xsl:value-of select="@Attr.Border" />;
      </xsl:if>
    </xsl:if>
    <xsl:if test="$prmBackground='1'">
      <xsl:if test="not(@Attr.BackgroundImageLayout='3' or @Attr.BackgroundImageLayout='4')">
        <xsl:if test="@Attr.BackgroundImage">
          background-image:url(<xsl:value-of select="@Attr.BackgroundImage" />);
        </xsl:if>
        <xsl:if test="@Attr.BackgroundImageLayout='2'">background-repeat:no-repeat;background-position:center center;</xsl:if>
        <xsl:if test="@Attr.BackgroundImageLayout='0'">
          background-repeat:no-repeat;background-position:top <xsl:value-of select="$pleft" />;
        </xsl:if>
        <xsl:if test="@Attr.Background">
          background-color:<xsl:value-of select="@Attr.Background" />;
        </xsl:if>
      </xsl:if>
    </xsl:if>
    <xsl:if test="$prmFont='1'">
      <xsl:call-template name="tplApplyFontStyles" />
    </xsl:if>
    <xsl:if test="$prmCursor='1'">
      <xsl:call-template name="tplApplyCursorStyle" />
    </xsl:if>
  </xsl:template>

  <!-- Apply margins to the current container -->
  <xsl:template name="tplApplyMargins">
    <xsl:if test="@Attr.MarginAll">
      padding:<xsl:value-of select="@Attr.MarginAll" />px;
    </xsl:if>
    <xsl:if test="@Attr.MarginLeft">
      padding-<xsl:value-of select="$pleft" />:<xsl:value-of select="@Attr.MarginLeft" />px;
    </xsl:if>
    <xsl:if test="@Attr.MarginRight">
      padding-<xsl:value-of select="$pright" />:<xsl:value-of select="@Attr.MarginRight" />px;
    </xsl:if>
    <xsl:if test="@Attr.MarginTop">
      padding-top:<xsl:value-of select="@Attr.MarginTop" />px;
    </xsl:if>
    <xsl:if test="@Attr.MarginBottom">
      padding-bottom:<xsl:value-of select="@Attr.MarginBottom" />px;
    </xsl:if>
  </xsl:template>

  <!-- Apply padding to the current container -->
  <xsl:template name="tplApplyPaddings">
    <xsl:if test="@Attr.PaddingAll">padding:<xsl:value-of select="@Attr.PaddingAll" />px;</xsl:if>
    <xsl:if test="@Attr.PaddingLeft">padding-<xsl:value-of select="$pleft" />:<xsl:value-of select="@Attr.PaddingLeft" />px;</xsl:if>
    <xsl:if test="@Attr.PaddingRight">padding-<xsl:value-of select="$pright" />:<xsl:value-of select="@Attr.PaddingRight" />px;</xsl:if>
    <xsl:if test="@Attr.PaddingTop">padding-top:<xsl:value-of select="@Attr.PaddingTop" />px;</xsl:if>
    <xsl:if test="@Attr.PaddingBottom">padding-bottom:<xsl:value-of select="@Attr.PaddingBottom" />px;</xsl:if>
  </xsl:template>

  <!-- Apply font to the current container -->
  <xsl:template name="tplApplyFontStyles">
    <xsl:param name="prmTarget" select="." />
    <xsl:param name="prmFont" select="$prmTarget/@Attr.Font" />
    <xsl:param name="prmForeColor" select="$prmTarget/@Attr.Fore" />
    
    <xsl:if test="$prmFont">font:<xsl:value-of select="$prmFont" />;</xsl:if>
    <xsl:if test="$prmForeColor">color:<xsl:value-of select="$prmForeColor" />;</xsl:if>
  </xsl:template>

  <!-- Apply cursor style to the current container -->
  <xsl:template name="tplApplyCursorStyle">
    <xsl:if test="@Attr.Cursor">
      cursor:<xsl:value-of select="@Attr.Cursor" />;
    </xsl:if>
  </xsl:template>

  <!-- Draws a button content layout -->
  <xsl:template name="tplDrawButtonContent">

    <!-- Text related parameters -->
    <xsl:param name="prmText" select="@Attr.Text" />
    <xsl:param name="prmTextClass" />
    <xsl:param name="prmTextAlign" select="@Attr.TextAlign" />
    <xsl:param name="prmTextImageRelation">
      <xsl:if test="@Attr.TextImageRelation"><xsl:value-of select="@Attr.TextImageRelation" /></xsl:if>
      <xsl:if test="not(@Attr.TextImageRelation)">4</xsl:if>
    </xsl:param>
    
    <!-- Image related parameters -->
    <xsl:param name="prmImage" select="@Attr.Image" />
    <xsl:param name="prmImageClass" />
    <xsl:param name="prmImageAlign" select="@Attr.ImageAlign" />
    <xsl:param name="prmImageHeight" select="@Attr.ImageHeight" />
    <xsl:param name="prmImageWidth" select="@Attr.ImageWidth" />

    <!-- State related parameters -->
    <xsl:param name="prmStateImage" />
    <xsl:param name="prmStateClass" />
    <xsl:param name="prmStateImageAlign" />
    <xsl:param name="prmStateImageId" />
    <xsl:param name="prmStateImageHeight" select="16" />
    <xsl:param name="prmStateImageWidth" select="16" />

    <!-- Dropdown related parameters -->
    <xsl:param name="prmDropDown" select="0" />
    <xsl:param name="prmDropDownWidth" select="1" />
    <xsl:param name="prmDropDownImage" />
    <xsl:param name="prmDropDownClass" />
    
    <!-- Layout related parameters -->
    <xsl:param name="prmLayoutPadding" select="2" />

    <!-- Calculate layout flags -->
    <xsl:variable name="varHasText" select="$prmText and not($prmText='')" />
    <xsl:variable name="varHasImage" select="$prmImage and not($prmImage='')" />
    <xsl:variable name="varHasImageAndText" select="$varHasImage and $varHasText" />
    
    <!-- Calculate the table layout -->
    <xsl:variable name="varColspan" select="1 + number($varHasImageAndText and ($prmTextImageRelation=4 or $prmTextImageRelation=8)) + number($prmDropDown)" />
    <xsl:variable name="varRowspan" select="1 + number($varHasImageAndText and ($prmTextImageRelation=1 or $prmTextImageRelation=2))" />
    
    <!-- Calculate the image style -->
    <xsl:variable name="varImageStyle">
      <xsl:if test="$prmImageHeight">height:<xsl:value-of select="$prmImageHeight" />px;</xsl:if>
      <xsl:if test="$prmImageWidth">width:<xsl:value-of select="$prmImageWidth" />px;</xsl:if>
    </xsl:variable>

    <table class="Common-ButtonTable" cellpadding="0" cellspacing="0">
      
      <!-- If the state image is in the middle -->
      <xsl:if test="$prmStateImageAlign='MiddleCenter'">
        <xsl:attribute name="id"><xsl:value-of select="$prmStateImageId" /></xsl:attribute>
        <xsl:attribute name="style">
          <xsl:call-template name="tplDrawBackground">
            <xsl:with-param name="prmImage" select="$prmStateImage" />
            <xsl:with-param name="prmImageAlign" select="$prmStateImageAlign" />
          </xsl:call-template>
        </xsl:attribute>  
      </xsl:if>
      
      <!-- set the cols to ensure proper auto sizing of the table-->
      <xsl:if test="$prmStateImage and contains($prmStateImageAlign,'Left')"><col width="{$prmStateImageWidth+$prmLayoutPadding}px" /></xsl:if>
      <xsl:if test="$varHasImage and $prmTextImageRelation=8"><col width="100%" /></xsl:if>
      <col />
      <xsl:if test="$varHasImage and $prmTextImageRelation=4"><col width="100%" /></xsl:if>
      <xsl:if test="$prmStateImage and contains($prmStateImageAlign,'Right')"><col width="{$prmStateImageWidth+$prmLayoutPadding}px" /></xsl:if>
      <xsl:if test="$prmDropDown"><col width="{$prmDropDownWidth}px" /></xsl:if>

      <!-- If the state image is in top center draw dedicated row  -->
      <xsl:if test="$prmStateImage and $prmStateImageAlign='TopCenter'">
        <tr>
          <td id="{$prmStateImageId}" class="{$prmStateClass}" colspan="{$varColspan}" height="{$prmStateImageHeight+$prmLayoutPadding}px">
            <xsl:attribute name="style">
              <xsl:call-template name="tplDrawBackground">
                <xsl:with-param name="prmImage" select="$prmStateImage" />
                <xsl:with-param name="prmImageAlign" select="$prmStateImageAlign" />
              </xsl:call-template>
            </xsl:attribute>
            <xsl:call-template name="tplDrawEmptyImage">
                <xsl:with-param name="prmImageHeight" select="$prmStateImageHeight" />
                <xsl:with-param name="prmImageWidth" select="$prmStateImageWidth" />
             </xsl:call-template>
          </td>
        </tr>
      </xsl:if>

      <tr>
        <!-- If the image above text or text above image we need an extra row  -->
        <xsl:if test="$prmStateImage and contains($prmStateImageAlign,'Left')">
          <td id="{$prmStateImageId}" class="{$prmStateClass}" rowspan="{$varRowspan}">
            <xsl:attribute name="style">
              <xsl:call-template name="tplDrawBackground">
                <xsl:with-param name="prmImage" select="$prmStateImage" />
                <xsl:with-param name="prmImageAlign" select="$prmStateImageAlign" />
              </xsl:call-template>
            </xsl:attribute>
             <xsl:call-template name="tplDrawEmptyImage">
                <xsl:with-param name="prmImageHeight" select="$prmStateImageHeight" />
                <xsl:with-param name="prmImageWidth" select="$prmStateImageWidth" />
             </xsl:call-template>
            
          </td>
        </xsl:if>

        <!-- If there is an image and it is before text or above text -->
        <xsl:if test="$varHasImage and ($prmTextImageRelation=1 or $prmTextImageRelation=4)">
          <td class="{$prmImageClass}">
            <xsl:attribute name="style">
              <xsl:if test="$prmTextImageRelation=1">
                height:1px;
                padding-bottom:<xsl:value-of select="$prmLayoutPadding" />px;
              </xsl:if>
              <xsl:if test="$prmTextImageRelation=4">
                padding-<xsl:value-of select="$right" />:<xsl:value-of select="$prmLayoutPadding" />px;
              </xsl:if>
            </xsl:attribute>
            <xsl:call-template name="tplCellAlign">
              <xsl:with-param name="prmAlign" select="$prmImageAlign" />
            </xsl:call-template>
            <img src="{$prmImage}" style="{$varImageStyle}" />
          </td>
        </xsl:if>

        <!-- If image after text / image before text / text above image / overlay -->
        <xsl:if test="($varHasText and ($prmTextImageRelation=2 or $prmTextImageRelation=8 or $prmTextImageRelation=4)) or $prmTextImageRelation = 0 or ($varHasText and not($varHasImage) and $prmTextImageRelation=1)">
          <td>
            <xsl:call-template name="tplCellAlign">
              <xsl:with-param name="prmAlign" select="$prmTextAlign" />
            </xsl:call-template>

            <xsl:attribute name="style">              
              <!-- If there is an image to overlay -->
              <xsl:if test="$prmTextImageRelation=0 and $varHasImage">
                <xsl:call-template name="tplDrawBackground">
                  <xsl:with-param name="prmImage" select="$prmImage" />
                  <xsl:with-param name="prmImageAlign" select="$prmImageAlign" />
                </xsl:call-template>
              </xsl:if>
            </xsl:attribute>
            <xsl:if test="$varHasText">
              <span class="{$prmTextClass}">
                <xsl:attribute name="style">
                  <xsl:call-template name="tplApplyFontStyles" />
                </xsl:attribute>
                <xsl:call-template name="tplDecodeTextAsHtml">
                  <xsl:with-param name="prmText" select="$prmText" />
                </xsl:call-template>
              </span>
            </xsl:if>
            <xsl:if test="not($varHasText)"><xsl:call-template name="tplDrawEmptyImage" /></xsl:if>
            </td>
        </xsl:if>

        <!-- If text before image and valid image -->
        <xsl:if test="$varHasImage and $prmTextImageRelation=8">
          <td class="{$prmImageClass}" style="padding-{$left}:{$prmLayoutPadding}px;">
            <xsl:call-template name="tplCellAlign">
              <xsl:with-param name="prmAlign" select="$prmImageAlign" />
            </xsl:call-template>
            <img src="{$prmImage}" style="{$varImageStyle}" />
          </td>
        </xsl:if>

        <xsl:if test="$prmStateImage and contains($prmStateImageAlign,'Right')">
          <td id="{$prmStateImageId}" class="{$prmStateClass}" rowspan="{$varRowspan}">
             <xsl:attribute name="style">
              <xsl:call-template name="tplDrawBackground">
                <xsl:with-param name="prmImage" select="$prmStateImage" />
                <xsl:with-param name="prmImageAlign" select="$prmStateImageAlign" />
              </xsl:call-template>
            </xsl:attribute>
             <xsl:call-template name="tplDrawEmptyImage">
                <xsl:with-param name="prmImageHeight" select="$prmStateImageHeight" />
                <xsl:with-param name="prmImageWidth" select="$prmStateImageWidth" />
             </xsl:call-template>
          </td>
        </xsl:if>

        <xsl:if test="$prmDropDown">
          <td class="{$prmDropDownClass}" align="center" valign="center" rowspan="{$varRowspan}">
            <xsl:if test="$prmDropDownImage">
              <img src="{$prmDropDownImage}" />
            </xsl:if>
          </td>
        </xsl:if>
      </tr>

      <!-- If the image above text or text above image we need an extra row  -->
      <xsl:if test="$varHasImageAndText and ($prmTextImageRelation=2 or $prmTextImageRelation=1)">
        <tr>
          <xsl:if test="$varHasImage and $prmTextImageRelation=2">
            <td class="{$prmImageClass}" style="height:1px;padding-top:{$prmLayoutPadding}px;">
              <xsl:call-template name="tplCellAlign">
                <xsl:with-param name="prmAlign" select="$prmImageAlign" />
              </xsl:call-template>
              <img src="{$prmImage}" style="{$varImageStyle}" />
            </td>
          </xsl:if>
          <xsl:if test="$prmTextImageRelation=1">
            <td>
              <xsl:call-template name="tplCellAlign">
                <xsl:with-param name="prmAlign" select="$prmTextAlign" />
              </xsl:call-template>
              <span class="{$prmTextClass}">
                <xsl:attribute name="style">
                  <xsl:call-template name="tplApplyFontStyles" />
              </xsl:attribute>
                <xsl:call-template name="tplDecodeTextAsHtml">
                  <xsl:with-param name="prmText" select="$prmText" />
                </xsl:call-template>
              </span>
            </td>
          </xsl:if>
        </tr>
      </xsl:if>

      <!-- If the state image is in bottom center draw dedicated row  -->
      <xsl:if test="$prmStateImage and $prmStateImageAlign='BottomCenter'">
        <tr>
          <td id="{$prmStateImageId}" class="{$prmStateClass}" colspan="{$varColspan}" height="{$prmStateImageHeight+$prmLayoutPadding}px;">
            <xsl:attribute name="style">
              <xsl:call-template name="tplDrawBackground">
                <xsl:with-param name="prmImage" select="$prmStateImage" />
                <xsl:with-param name="prmImageAlign" select="$prmStateImageAlign" />
              </xsl:call-template>
            </xsl:attribute>
            <xsl:call-template name="tplDrawEmptyImage">
                <xsl:with-param name="prmImageHeight" select="$prmStateImageHeight" />
                <xsl:with-param name="prmImageWidth" select="$prmStateImageWidth" />
             </xsl:call-template>
          </td>
        </tr>
      </xsl:if>

    </table>
  </xsl:template>

  <!-- Apply style to a given control -->
  <xsl:template match="*" mode="modApplyStyle">
    <xsl:call-template name="tplApplyStyles" />
  </xsl:template>

  <!-- Draws an error image which blinks and has a title -->
  <xsl:template name="tplDrawErrorIcon">
    <div>
      <xsl:attribute name="title">
        <xsl:call-template name="tplDecodeText">
          <xsl:with-param name="prmText" select="@Attr.ErrorMessage" />
        </xsl:call-template>
      </xsl:attribute>                     
      <xsl:attribute name="style">
        position:absolute;top:0px;width:0px;height:100%;
        <xsl:if test="contains(@Attr.ErrorIconAlignment,'Right')">
          <xsl:value-of select="$right" />:-1px;
        </xsl:if>
        <xsl:if test="contains(@Attr.ErrorIconAlignment,'Left')">
          <xsl:value-of select="$left" />:-1px;
        </xsl:if>
        <xsl:if test="contains(@Attr.ErrorIconAlignment,'Top')">top:0px;</xsl:if>
        <xsl:if test="contains(@Attr.ErrorIconAlignment,'Middle')">top:50%;</xsl:if>
        <xsl:if test="contains(@Attr.ErrorIconAlignment,'Bottom')">bottom:0px;</xsl:if>
      </xsl:attribute>


      <xsl:choose>
        <xsl:when test="not(@MarkRequired='0')">
          <span>
            <xsl:attribute name="style">
              position:absolute;width:16px;height:16px;color:red;
              <xsl:if test="contains(@Attr.ErrorIconAlignment,'Right')">
                <xsl:value-of select="$right" />:-18px;
              </xsl:if>
              <xsl:if test="contains(@Attr.ErrorIconAlignment,'Left')">
                <xsl:value-of select="$left" />:-18px;
              </xsl:if>
              <xsl:if test="contains(@Attr.ErrorIconAlignment,'Top')">top:0px;</xsl:if>
              <xsl:if test="contains(@Attr.ErrorIconAlignment,'Middle')">top:-8px;</xsl:if>
              <xsl:if test="contains(@Attr.ErrorIconAlignment,'Bottom')">bottom:0px;</xsl:if>
            </xsl:attribute>
            <xsl:attribute name="src">
              <xsl:if test="@Attr.ErrorIcon and not(@Attr.ErrorIcon='')">
                <xsl:value-of select="@Attr.ErrorIcon" />
              </xsl:if>
              <xsl:if test="not(@Attr.ErrorIcon and not(@Attr.ErrorIcon=''))">[Skin.CommonPath]ErrorProvider.gif.wgx</xsl:if>
            </xsl:attribute>
            *</span>
        </xsl:when>
        <xsl:otherwise>
          <img onload="mobjApp.Web_ErrorProviderBlink('{@Id}',this,400,4)">
            <xsl:attribute name="style">
              position:absolute;width:16px;height:16px;
              <xsl:if test="contains(@Attr.ErrorIconAlignment,'Right')">
                <xsl:value-of select="$right" />:-20px;
              </xsl:if>
              <xsl:if test="contains(@Attr.ErrorIconAlignment,'Left')">
                <xsl:value-of select="$left" />:-20px;
              </xsl:if>
              <xsl:if test="contains(@Attr.ErrorIconAlignment,'Top')">top:0px;</xsl:if>
              <xsl:if test="contains(@Attr.ErrorIconAlignment,'Middle')">top:-8px;</xsl:if>
              <xsl:if test="contains(@Attr.ErrorIconAlignment,'Bottom')">bottom:0px;</xsl:if>
            </xsl:attribute>
            <xsl:attribute name="src">
              <xsl:if test="@Attr.ErrorIcon and not(@Attr.ErrorIcon='')">
                <xsl:value-of select="@Attr.ErrorIcon" />
              </xsl:if>
              <xsl:if test="not(@Attr.ErrorIcon and not(@Attr.ErrorIcon=''))">[Skin.CommonPath]ErrorProvider.gif.wgx</xsl:if>
            </xsl:attribute>
          </img>
        </xsl:otherwise>
      </xsl:choose>
      
 
    </div>
  </xsl:template>

  <!-- Draws and empty image by default as 1px X 1px -->
  <xsl:template name="tplDrawEmptyImage">
    <xsl:param name="prmFillContainer" select="'0'" />
    <xsl:param name="prmImageHeight" select="1" />
    <xsl:param name="prmImageWidth" select="1" />
    <xsl:param name="prmPositionStyle" select="'static'" />

    <xsl:variable name="varImageHeight">
      <xsl:choose>
        <xsl:when test="$prmFillContainer='1'">100%</xsl:when>
        <xsl:otherwise><xsl:value-of select="$prmImageHeight" />px</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="varImageWidth">
      <xsl:choose>
        <xsl:when test="$prmFillContainer='1'">100%</xsl:when>
        <xsl:otherwise><xsl:value-of select="$prmImageWidth" />px</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    
    <img src="[Skin.Path]Empty.gif.wgx" style="position:{$prmPositionStyle};width:{$varImageWidth};height:{$varImageHeight};" />
  </xsl:template>


  <!-- Background Image Stretch and Zoom Apply -->
  <xsl:template name="tplDrawFillingBackgroundImage">
    <xsl:if test="@Attr.BackgroundImageLayout='3'">
      <img class="Common-StrechedBG" src="{@Attr.BackgroundImage}">
        <xsl:attribute name="style">
          <xsl:if test="@Attr.Background">
            background-color:<xsl:value-of select="@Attr.Background" />;
          </xsl:if>
        </xsl:attribute>
      </img>
    </xsl:if>
    <xsl:if test="@Attr.BackgroundImageLayout='4'">
      <div>
        <xsl:attribute name="style">
          position:absolute;height:100%;width:100%;text-align:center;overflow:hidden;
          <xsl:if test="@Attr.Background">
            background-color:<xsl:value-of select="@Attr.Background" />;
          </xsl:if>
        </xsl:attribute>
        <img class="Common-ZoomedBG" src="{@Attr.BackgroundImage}" />
      </div>
    </xsl:if>
  </xsl:template>
  
  <!-- Draws Scrollbars -->
  <xsl:template name="tplDrawScrollbars">
    <xsl:choose>
      <xsl:when test="@Attr.Scrollbars='B'">overflow:auto;</xsl:when>
      <xsl:when test="@Attr.Scrollbars='H'">overflow-y:hidden;overflow-x:auto;</xsl:when>
      <xsl:when test="@Attr.Scrollbars='V'">overflow-y:auto;overflow-x:hidden;</xsl:when>
      <xsl:otherwise>overflow:hidden;</xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  
  <xsl:template name="tplDrawPaging">
    <xsl:param name="prmID" select="@Attr.Id" />
    <xsl:param name="prmCurrentPage" select="@Attr.CurrentPage" />
    <xsl:param name="prmTotalPages" select="@Attr.TotalPages" />

    <!--jrt add total items count-->
    <xsl:param name="prmTotalItems" />
    <xsl:param name="prmPageSize" />
    <xsl:param name="prmPagingBoxClass" />
    
    <xsl:param name="prmPagingFirstImageWidth" />
    <xsl:param name="prmPagingFirstButtonClass" />
    <xsl:param name="prmPagingPreviousImageWidth" />
    <xsl:param name="prmPagingPrevButtonClass" />
    <xsl:param name="prmPagingBoxWidth" />
    <xsl:param name="prmPagingStatusBoxClass" />
    <xsl:param name="prmPagingNextImageWidth" />
    <xsl:param name="prmPagingNextButtonClass" />
    <xsl:param name="prmPagingLastImageWidth" />
    <xsl:param name="prmPagingLastButtonClass" />
    
    <table style="height:100%;" border="0" cellpadding="0" cellspacing="0" class="Common-PagingPanel Common-FontData" dir="{$dir}" align="center">
      <tr>
        <td width="10"></td>
        <td title="第一页">
          <xsl:attribute name="class"><xsl:value-of select="$prmPagingFirstImageWidth" /><xsl:if test="$prmCurrentPage=1"> Common-Disabled</xsl:if>
          </xsl:attribute>
          <a >
            <xsl:if test="not($prmCurrentPage=1)">
              <xsl:attribute name="onclick">mobjApp.List_NavigateHome('<xsl:value-of select="$prmID" />');</xsl:attribute>
            </xsl:if>
            <div class="{$prmPagingFirstButtonClass}"> </div>
          </a>
        </td>
        <td title="上一页">
          <xsl:attribute name="class">
            <xsl:value-of select="$prmPagingPreviousImageWidth" /><xsl:if test="$prmCurrentPage=1"> Common-Disabled</xsl:if>
          </xsl:attribute>
          <a>
            <xsl:if test="not($prmCurrentPage=1)">
              <xsl:attribute name="onclick">mobjApp.List_NavigateBack('<xsl:value-of select="$prmID" />');</xsl:attribute>
            </xsl:if>
            <div class="{$prmPagingPrevButtonClass}"> </div>
          </a>
        </td>
        <td dir="ltr" width="{$prmPagingBoxWidth}px">
          <div class="{$prmPagingStatusBoxClass}">
            <xsl:value-of select="$prmCurrentPage" /> / <xsl:value-of select="$prmTotalPages" />        
          </div>
        </td>
        <td title="下一页">
          <xsl:attribute name="class">
            <xsl:value-of select="$prmPagingNextImageWidth" /><xsl:if test="$prmCurrentPage=$prmTotalPages"> Common-Disabled</xsl:if>
          </xsl:attribute>
          <a>
            <xsl:if test="$prmCurrentPage &lt; $prmTotalPages">
              <xsl:attribute name="onclick">mobjApp.List_NavigateNext('<xsl:value-of select="$prmID" />');</xsl:attribute>
            </xsl:if>
            <div class="{$prmPagingNextButtonClass}"> </div>
          </a>
        </td>
        <td title="最末页">
          <xsl:attribute name="class">
            <xsl:value-of select="$prmPagingLastImageWidth" /><xsl:if test="$prmCurrentPage=$prmTotalPages"> Common-Disabled</xsl:if>
          </xsl:attribute>
          <a>
            <xsl:if test="$prmCurrentPage &lt; $prmTotalPages">
              <xsl:attribute name="onclick">mobjApp.List_NavigateEnd('<xsl:value-of select="$prmID" />');</xsl:attribute>
            </xsl:if>
            <div class="{$prmPagingLastButtonClass}"> </div>
          </a>
        </td>
        <td style="text-align:right;">
          <xsl:if test="$prmTotalItems!=''">
          <table border="0" cellpadding="0" cellspacing="0"  style="text-align:right;width:100%;"  class="Common-FontData" >
            <td style="text-align:right; vertical-align:middle;padding-left:16px;" noWrap="noWrap">
              共<span style="color:Blue;">
                <xsl:value-of select="$prmTotalItems"/>
              </span>条记录，每页
            </td>
            <td style="width:23px;">
              <INPUT id="VWG{../@Attr.Id}_pagesize" style="width:100%;position:relative;OVERFLOW-X: hidden; OVERFLOW-Y: hidden; TEXT-TRANSFORM: none; HEIGHT: 18px;border-width:1px;" dir="ltr" 
                     value="{$prmPageSize}" tabIndex="-1"  vwgeditable="1" vwgfocuselement="1" 
                     onfocus="Web_SetInputSelection(this);"
                      onblur="mobjApp.PageSize_HandleEvents('{@Id}','blur',this,event)"
                     onkeypress="mobjApp.PageSize_HandleEvents('{@Id}','keypress',this,event)"
                     class="{$prmPagingBoxClass}"
                     >
                
              </INPUT>
            </td>
            <td style="width:40px;text-align:left; vertical-align:middle;">条记录</td>
          </table>
          </xsl:if>
        </td>
      </tr>
    </table>    
  </xsl:template>
  
</xsl:stylesheet>

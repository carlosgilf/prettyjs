<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

	<!-- Details Mode -->
	<xsl:template match="WC:Tags.ListView[@Attr.View='Details']" mode="modContent">
    <xsl:attribute name="Class">Common-Unselectable ListView-Control</xsl:attribute>
    <xsl:variable name="varCols" select="Tags.Column" />
    <xsl:variable name="varRows" select="Tags.Row | Tags.Group | Tags.ListViewPanel" />
    <xsl:variable name="varCheckBoxes" select="@Attr.CheckBoxes" />
    <xsl:variable name="varGridLines" select="@Attr.GridLines" />
    <xsl:variable name="varHeaders" select="not(@Attr.HeaderStyle='0')" />
    <!--jrt add showPg attr ,control always show paging bar-->
    <xsl:variable name="varPaging" select="@Attr.TotalPages &gt; 1 or not(@showPg='0')" />
    <xsl:variable name="varHeight" select="@Attr.HeaderHeight" />
		<table dir="LTR" style="table-layout:fixed" WIDTH="100%" HEIGHT="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
			<xsl:if test="$varHeaders">
			<tr height="{$varHeight}px">
				<td>
          <div dir="{$dir}" id="HEADER_{@Id}" style="overflow:hidden;width:100%;height:100%">
            <xsl:call-template name="tplListViewDrawHeaders">
              <xsl:with-param name="prmCols" select="$varCols" />
              <xsl:with-param name="prmCheckBoxes" select="$varCheckBoxes" />
              <xsl:with-param name="prmGridLines" select="$varGridLines" />
            </xsl:call-template>
          </div>
				</td>
			</tr>
			</xsl:if>
			<tr>
				<td valign="top">
          <div dir="{$dir}" style="overflow:auto;width:100%;height:100%">
            <xsl:call-template name="tplListViewDrawDetailsRows">
              <xsl:with-param name="prmCols" select="$varCols" />
              <xsl:with-param name="prmRows" select="$varRows" />
              <xsl:with-param name="prmCheckBoxes" select="$varCheckBoxes" />
              <xsl:with-param name="prmGridLines" select="$varGridLines" />
            </xsl:call-template>
          </div>
				</td>
			</tr>
			<xsl:if test="$varPaging">
				<tr class="ListView-PagingPanelHeight">
					<td class="ListView-PagingPanelStyle">
            <xsl:call-template name="tplDrawListViewPaging" />
					</td>
				</tr>
			</xsl:if>
		</table>
	</xsl:template>

  <!-- List Mode -->
  <xsl:template match="WC:Tags.ListView[@Attr.View='List']" mode="modContent">
    <xsl:variable name="varCheckBoxes" select="@Attr.CheckBoxes" />
    <xsl:variable name="varPaging" select="@Attr.TotalPages &gt; 1 or not(@showPg='0')" />
    <xsl:attribute name="Class">Common-Unselectable ListView-Control</xsl:attribute>
    <table dir="LTR" jrt="1" style="table-layout:fixed" WIDTH="100%" HEIGHT="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
      <tr>
        <td valign="top">
          <div dir="{$dir}" style="width:100%;height:100%" onscroll="mobjApp.Web_SyncScroll(this,window.HEADER_{@Id},1,'{$dir}')" onresize="mobjApp.Web_SyncScroll(this,window.HEADER_{@Id},1,'{$dir}')">
            <div vwgscrollable="1" data-scrollable="yes" vwgfocuselement="1" tabindex="-1">
              <xsl:attribute name="style">
                width:100%;height:100%;
                <xsl:if test="not (@Attr.Scrollbars)">overflow:auto;</xsl:if>
                <xsl:if test="@Attr.Scrollbars='0'">overflow:hidden;</xsl:if>
              </xsl:attribute>
              <xsl:if test="not(@Attr.Enabled='0')">
                <xsl:attribute name="onkeydown">mobjApp.ListView_KeyDown('<xsl:value-of select="@Id" />',window,event);</xsl:attribute>
              </xsl:if>
              <xsl:call-template name="tplRestoreScroll" />
              <xsl:call-template name="tplListViewDrawListRows">
                <xsl:with-param name="prmCheckBoxes" select="$varCheckBoxes" />
              </xsl:call-template>
            </div>
          </div>
        </td>
      </tr>
      <xsl:if test="$varPaging">
        <tr class="ListView-PagingPanelHeight">
          <td class="ListView-PagingPanelStyle">
            <xsl:call-template name="tplDrawListViewPaging" />
          </td>
        </tr>
      </xsl:if>
    </table>
  </xsl:template>

  <!-- Small icons Mode -->
  <xsl:template match="WC:Tags.ListView[@Attr.View='SmallIcon']" mode="modContent">
    <xsl:variable name="varCheckBoxes" select="@Attr.CheckBoxes" />
    <xsl:variable name="varPaging" select="@Attr.TotalPages &gt; 1 or not(@showPg='0')" />
    <xsl:attribute name="Class">Common-Unselectable ListView-Control</xsl:attribute>
    <table dir="LTR" style="table-layout:fixed" WIDTH="100%" HEIGHT="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
      <tr>
        <td valign="top">
          <div dir="{$dir}" style="width:100%;height:100%" onscroll="mobjApp.Web_SyncScroll(this,window.HEADER_{@Id},1,'{$dir}')" onresize="mobjApp.Web_SyncScroll(this,window.HEADER_{@Id},1,'{$dir}')">
            <div vwgscrollable="1" data-scrollable="yes" vwgfocuselement="1" tabindex="-1">
              <xsl:attribute name="style">
                width:100%;height:100%;
                <xsl:if test="not (@Attr.Scrollbars)">overflow:auto;</xsl:if>
                <xsl:if test="@Attr.Scrollbars='0'">overflow:hidden;</xsl:if>
              </xsl:attribute>
              <xsl:if test="not(@Attr.Enabled='0')">
                <xsl:attribute name="onkeydown">mobjApp.ListView_KeyDown('<xsl:value-of select="@Id" />',window,event);</xsl:attribute>
              </xsl:if>
              <xsl:call-template name="tplRestoreScroll" />
              <xsl:call-template name="tplListViewDrawSmallIconsRows">
                <xsl:with-param name="prmCheckBoxes" select="$varCheckBoxes" />
              </xsl:call-template>
            </div>
          </div>
        </td>
      </tr>
      <xsl:if test="$varPaging">
        <tr class="ListView-PagingPanelHeight">
          <td class="ListView-PagingPanelStyle">
            <xsl:call-template name="tplDrawListViewPaging" />
          </td>
        </tr>
      </xsl:if>
    </table>
  </xsl:template>

  <!-- Large icons Mode -->
  <xsl:template match="WC:Tags.ListView[@Attr.View='LargeIcon']" mode="modContent">
    <xsl:variable name="varCheckBoxes" select="@Attr.CheckBoxes" />
    <xsl:variable name="varPaging" select="@Attr.TotalPages &gt; 1 or not(@showPg='0')" />
    <xsl:attribute name="Class">Common-Unselectable ListView-Control</xsl:attribute>
    <table dir="LTR" style="table-layout:fixed" WIDTH="100%" HEIGHT="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
      <tr>
        <td valign="top">
          <div dir="{$dir}" style="width:100%;height:100%" onscroll="mobjApp.Web_SyncScroll(this,window.HEADER_{@Id},1,'{$dir}')" onresize="mobjApp.Web_SyncScroll(this,window.HEADER_{@Id},1,'{$dir}')">
            <div vwgscrollable="1" data-scrollable="yes" vwgfocuselement="1" tabindex="-1">
              <xsl:attribute name="style">
                width:100%;height:100%;
                <xsl:if test="not (@Attr.Scrollbars)">overflow:auto;</xsl:if>
                <xsl:if test="@Attr.Scrollbars='0'">overflow:hidden;</xsl:if>
              </xsl:attribute>
              <xsl:if test="not(@Attr.Enabled='0')">
                <xsl:attribute name="onkeydown">mobjApp.ListView_KeyDown('<xsl:value-of select="@Id" />',window,event);</xsl:attribute>
              </xsl:if>
              <xsl:call-template name="tplRestoreScroll" />
              <xsl:call-template name="tplListViewDrawLargeIconsRows">
                <xsl:with-param name="prmCheckBoxes" select="$varCheckBoxes" />
              </xsl:call-template>
            </div>
          </div>
        </td>
      </tr>
      <xsl:if test="$varPaging">
        <tr class="ListView-PagingPanelHeight">
          <td class="ListView-PagingPanelStyle">
            <xsl:call-template name="tplDrawListViewPaging" />
          </td>
        </tr>
      </xsl:if>
    </table>
  </xsl:template>

  <xsl:template match="Tags.Row[../@Attr.View='Details']">
    <xsl:call-template name="tplDrawDetailsRow">
      <xsl:with-param name="prmCheckBoxes" select="../@Attr.CheckBoxes" />
      <xsl:with-param name="prmCols" select="../Tags.Column" />
      <xsl:with-param name="prmPanel" select="0" />
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>

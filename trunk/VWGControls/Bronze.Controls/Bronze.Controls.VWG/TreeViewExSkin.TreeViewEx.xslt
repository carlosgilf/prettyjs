<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.TreeView[@Attr.CustomStyle='TreeViewEx']" mode="modContent">
    <xsl:attribute name="Class">TreeView-Control</xsl:attribute>
    <div tag="jrtttttttttttttttt" class="Common-Unselectable TreeView-Container" dir="{$dir}" onkeydown="mobjApp.TreeView_KeyDown({@Id},window,event);" vwgfocuselement="1" tabindex="-1">
      <xsl:call-template name="tplApplyScrollable" />
      <div class="TreeView-PaddingContainer">
        <xsl:apply-templates select="TN[@JRT='1']" >
          <xsl:with-param name="prmTreeView" select="." />
        </xsl:apply-templates>
        <xsl:if test="count(TN)=0"> </xsl:if>
      </div>
    </div>
  </xsl:template>

  <!-- TreeNode -->
  <xsl:template match="TN[@JRT='1']">

    <!-- TreeNode parameters-->
    <xsl:param name="prmTreeView" select="ancestor::WC:TV" />
    <xsl:param name="prmCheckBoxes" select="@Attr.CheckBoxes='1'" />
    <xsl:param name="prmStateImageChecked" select="$prmTreeView/@Attr.StateImageChecked" />
    <xsl:param name="prmStateImageUnchecked" select="$prmTreeView/@Attr.StateImageUnchecked" />
    <xsl:param name="prmHidePlusMinus" select="$prmTreeView/@Attr.HidePlusMinus" />
    <xsl:param name="prmShowLines" select="$prmTreeView/@Attr.ShowLines" />
    <xsl:param name="prmHasNext" select="following-sibling::TN[position()=1]" />
    <xsl:param name="prmHasPrev" select="1" />
    <xsl:param name="prmIsRootNode" select="name(parent::node())='WC:TV'" />
    <xsl:param name="prmExpandLable" select="not(@Attr.StateImage) and not(@Attr.CheckBoxes='1') and ../*[@Attr.StateImage]" />

    <!-- TreeNode root element-->
    <div id="VWG_{@Id}" vwgevents="{@Attr.Events}">

      <xsl:call-template name="tplApplyDragAndDrop" />

      <!-- TreeNode row container -->
      <div id="VWGNODE_{@Id}" vwgtype="root" onmouseleave="mobjApp.TreeViewEx_MonseLeave(event,this);" onmouseenter="mobjApp.TreeViewEx_MouseEnter(event,this);"
           onmousedown="mobjApp.TreeViewEx_HandleEvent({@Id},'{$prmTreeView/@Attr.Id}','mousedown',window,event)" onmouseup="mobjApp.TreeViewEx_HandleEvent({@Id},'{$prmTreeView/@Attr.Id}','mouseup',window,event)" ondblclick="mobjApp.TreeViewEx_HandleEvent({@Id},'{$prmTreeView/@Attr.Id}','dblclick',window,event)" onclick="mobjApp.TreeViewEx_HandleEvent({@Id},'{$prmTreeView/@Attr.Id}','click',window,event)">

        <xsl:choose>
          <xsl:when test="$prmTreeView/@selectFullLine='1' and @Attr.Selected='1'">
            <xsl:attribute name="class">TreeView-RowContainer TreeView-RowContainer_Selected</xsl:attribute>
          </xsl:when>
          <xsl:otherwise>
            <xsl:attribute name="class">TreeView-RowContainer</xsl:attribute>
          </xsl:otherwise>
        </xsl:choose>

        <!--jrt set TreeNode height-->
        <xsl:attribute name="style">
          <xsl:choose>
            <xsl:when test="not(@Attr.Text='')">height:<xsl:value-of select="$prmTreeView/@Attr.ItemHeight" />px;
            </xsl:when>
            <xsl:otherwise>height:8px;line-height:8px;</xsl:otherwise>
          </xsl:choose>
        </xsl:attribute>

      
        <!-- TreeNode joint container -->
        <div id="VWGJOINT_{@Id}" class="Common-HandCursor TreeView-ImageContainer" vwgtype="joint">

          <xsl:attribute name="style">

            <!-- If we need to draw the joint padding -->
            <xsl:if test="not($prmHidePlusMinus) or ($prmShowLines='1')">
              padding-<xsl:value-of select="$left" />:17px;
              background-position:<xsl:value-of select="$left" /> center;
            </xsl:if>

            <!-- If we need to draw the joint -->
            <xsl:if test="not($prmIsRootNode) or ($prmShowLines='1') or not($prmHidePlusMinus)">
              <xsl:choose>
                <xsl:when test="count(TN)&gt;0 and not(@Attr.Expanded='0') and not($prmHidePlusMinus)">
                  <xsl:choose>
                    <xsl:when test="$prmShowLines='1' and $prmHasNext and $prmHasPrev">
                      background-image:url([Skin.Path]TreeView11<xsl:value-of select="$dir" />0.gif.wgx);
                    </xsl:when>
                    <xsl:when test="$prmShowLines='1' and $prmHasNext and not($prmHasPrev)">
                      background-image:url([Skin.Path]TreeView01<xsl:value-of select="$dir" />0.gif.wgx);
                    </xsl:when>
                    <xsl:when test="$prmShowLines='1' and not($prmHasNext) and $prmHasPrev">
                      background-image:url([Skin.Path]TreeView10<xsl:value-of select="$dir" />0.gif.wgx);
                    </xsl:when>
                    <xsl:otherwise>
                      background-image:url([Skin.Path]TreeView0.gif.wgx);
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:when>
                <xsl:when test="not(@Attr.HasNodes='0') and @Attr.Expanded='0' and not($prmHidePlusMinus)">
                  <xsl:choose>
                    <xsl:when test="$prmShowLines='1' and $prmHasNext and $prmHasPrev">
                      background-image:url([Skin.Path]TreeView11<xsl:value-of select="$dir" />1.gif.wgx);
                    </xsl:when>
                    <xsl:when test="$prmShowLines='1' and $prmHasPrev and not($prmHasNext)">
                      background-image:url([Skin.Path]TreeView10<xsl:value-of select="$dir" />1.gif.wgx);
                    </xsl:when>
                    <xsl:when test="$prmShowLines='1' and not($prmHasPrev) and $prmHasNext">
                      background-image:url([Skin.Path]TreeView01<xsl:value-of select="$dir" />1.gif.wgx);
                    </xsl:when>
                    <xsl:otherwise>
                      background-image:url([Skin.Path]TreeView1.gif.wgx);
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:if test="not($prmShowLines='1')">
                    background-image:url([Skin.Path]Empty.gif.wgx);
                  </xsl:if>
                  <xsl:if test="$prmShowLines='1'">
                    <xsl:choose>
                      <xsl:when test="$prmShowLines='1' and $prmHasNext and $prmHasPrev">
                        background-image:url([Skin.Path]TreeViewEmpty11<xsl:value-of select="$dir" />.gif.wgx);
                      </xsl:when>
                      <xsl:when test="$prmShowLines='1' and $prmHasNext and not($prmHasPrev)">
                        background-image:url([Skin.Path]TreeViewEmpty01<xsl:value-of select="$dir" />.gif.wgx);
                      </xsl:when>
                      <xsl:when test="$prmShowLines='1' and not($prmHasNext) and $prmHasPrev">
                        background-image:url([Skin.Path]TreeViewEmpty10<xsl:value-of select="$dir" />.gif.wgx);
                      </xsl:when>
                    </xsl:choose>
                  </xsl:if>
                </xsl:otherwise>
              </xsl:choose>
            </xsl:if>
          </xsl:attribute>

          <!-- TreeNode checkbox / stateimage container -->
          <div id="VWGCHECKBOX_{@Id}" class="Common-HandCursor TreeView-ImageContainer" vwgtype="checkbox">

            <!-- If we need to draw the checkbox or the state image -->
            <xsl:choose>
              <xsl:when test="$prmCheckBoxes">
                <xsl:attribute name="style">
                  padding-<xsl:value-of select="$left" />:17px;
                  background-position:<xsl:value-of select="$left" /> center;

                  <!--If there is a state image defined (with CheckBoxes)-->
                  <xsl:if test="$prmStateImageChecked">
                    <xsl:choose>
                      <xsl:when test="@Attr.Checked='1'">
                        background-image:url(<xsl:value-of select="$prmStateImageChecked" />);
                      </xsl:when>
                      <xsl:otherwise>
                        background-image:url(<xsl:value-of select="$prmStateImageUnchecked" />);
                      </xsl:otherwise>
                    </xsl:choose>
                  </xsl:if>

                  <!--If there is NOT a state image defined, only CheckBoxes -->
                  <xsl:if test="not($prmStateImageChecked)">
                    <xsl:choose>
                      <xsl:when test="@Attr.Checked='1'">
                        background-image:url([Skin.Path]CheckBox1.gif.wgx);
                      </xsl:when>
                      <xsl:otherwise>
                        background-image:url([Skin.Path]CheckBox0.gif.wgx);
                      </xsl:otherwise>
                    </xsl:choose>
                  </xsl:if>
                </xsl:attribute>
              </xsl:when>
              <xsl:when test="(@Attr.StateImage) and not(@Attr.CheckBoxes='1')">
                <xsl:attribute name="style">
                  padding-<xsl:value-of select="$left" />:17px;
                  background-position:<xsl:value-of select="$left" /> center;
                  background-image:url(<xsl:value-of select="@Attr.StateImage" />);
                </xsl:attribute>
              </xsl:when>
            </xsl:choose>

            <!-- TreeNode icon container -->
            <div id="VWGICON_{@Id}" class="TreeView-ImageContainer" vwgtype="icon">

              <!-- If we need to draw node icon -->
              <xsl:if test="@Attr.Image">
                <xsl:attribute name="style">
                  padding-<xsl:value-of select="$left" />:17px;
                  background-position:<xsl:value-of select="$left" /> center;

                  <xsl:choose>
                    <xsl:when test="@Attr.Selected='1' and @Attr.SelectedImage">
                      background-image:url(<xsl:value-of select="@Attr.SelectedImage" />);
                    </xsl:when>
                    <xsl:when test="count(TN)&gt;0 and not(@Attr.Expanded='0') and @Attr.ExpandedImage">
                      background-image:url(<xsl:value-of select="@Attr.ExpandedImage" />);
                    </xsl:when>
                    <xsl:otherwise>
                      background-image:url(<xsl:value-of select="@Attr.Image" />);
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:attribute>
              </xsl:if>

              <!-- TreeNode text container -->
              <div  id="VWGTXT_{@Id}" class="Common-HandCursor TreeView-TextContainer" vwgtype="text">

                <xsl:choose>
                  <xsl:when test="not($prmTreeView/@selectFullLine='1') and @Attr.Selected='1'">
                    <xsl:attribute name="class">Common-HandCursor TreeView-TextContainer TreeView-TextContainer_Selected</xsl:attribute>
                  </xsl:when>
                  <xsl:otherwise>
                    <xsl:attribute name="class">Common-HandCursor TreeView-TextContainer</xsl:attribute>
                  </xsl:otherwise>
                </xsl:choose>
                
                <xsl:call-template name="tplSetToolTip" />

                <nobr id="VWGLE_{@Id}" class="TreeView-Label"  vwgtype="label">
                  <xsl:if test="$prmTreeView/@Attr.LabelEdit='1' and @Attr.Selected='1'">
                    <xsl:attribute name="vwglabeledit">1</xsl:attribute>
                  </xsl:if>
                  <xsl:attribute name="style">
                    <xsl:if test="@Attr.Font or @Attr.Fore">
                      <xsl:call-template name="tplApplyFontStyles" />;
                    </xsl:if>
                    <xsl:if test="(not(@Attr.Font) and $prmTreeView/@Attr.Font) or (not(@Attr.Fore) and $prmTreeView/@Attr.Fore)">
                      <xsl:call-template name="tplApplyFontStyles">
                        <xsl:with-param name="prmTarget" select="$prmTreeView" />
                      </xsl:call-template>;
                    </xsl:if>
                    <xsl:if test="@Attr.Background">
                      background:<xsl:value-of select="@Attr.Background" />;
                    </xsl:if>
                    <xsl:if test="not(@Attr.Text='') and $prmTreeView/@Attr.ItemHeight">
                      line-height:<xsl:value-of select="$prmTreeView/@Attr.ItemHeight"/>px;
                    </xsl:if>
                    <xsl:if test="@Attr.Text=''"> 
                      display:none;
                    </xsl:if>
                  </xsl:attribute>
                  <xsl:if test="@Attr.Text and not(@Attr.Text='')">
                    <xsl:choose>
                      <xsl:when test="($prmTreeView/@showHtml)='1'">
                        <!--jrt 支持现实html-->
                        <img src="[Skin.CommonPath]Empty.gif.wgx" onload="$(this).replaceWith($(this).attr('vwgsource'))">
                          <xsl:attribute name="vwgsource">
                            <xsl:value-of select="@Attr.Text" />
                          </xsl:attribute>
                        </img>
                      </xsl:when>
                      <xsl:otherwise>
                        <xsl:call-template name="tplDecodeTextAsHtml" />
                      </xsl:otherwise>
                    </xsl:choose>
                  </xsl:if>
                 
                </nobr>
              </div>
            </div>
          </div>
        </div>
      </div>

      <!-- If there are sub nodes-->
      <xsl:if test="count(TN)&gt;0">

        <!-- TreeNode child container element-->
        <div id="VWGSUBS_{@Id}" class="TreeView-SubNodesContainer">

          <xsl:attribute name="style">
            padding-<xsl:value-of select="$left" />:17px;
            <xsl:if test="@Attr.Expanded='0' or @Attr.Loaded='0'">
              display:none;
            </xsl:if>
            <xsl:if test="not($prmIsRootNode) or ($prmShowLines='1') or not($prmHidePlusMinus)">
              <xsl:if test="$prmShowLines='1' and $prmHasNext">
                background-image:url([Skin.Path]TreeViewConnector<xsl:value-of select="$dir" />.gif.wgx);
                background-position:<xsl:value-of select="$left" /> top;
                background-repeat:repeat-y;
              </xsl:if>
            </xsl:if>
          </xsl:attribute>

          <!--Check if node is expanded or loaded-->
          <xsl:if test="not(@Attr.Expanded='0') or not(@Attr.Loaded='0')">
            <xsl:apply-templates select="TN[@JRT='1']" >
              <xsl:with-param name="prmTreeView" select="$prmTreeView" />
              <xsl:with-param name="prmHidePlusMinus" select="$prmHidePlusMinus" />
            </xsl:apply-templates>
          </xsl:if>
        </div>
      </xsl:if>

    </div>
  </xsl:template>

  
</xsl:stylesheet>



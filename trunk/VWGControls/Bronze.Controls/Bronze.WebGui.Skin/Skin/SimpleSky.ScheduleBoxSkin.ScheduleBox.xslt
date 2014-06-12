<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <xsl:template match="WC:Tags.ScheduleBox[@Attr.View='Month']" mode="modContent">
    <xsl:attribute name="class">ScheduleBox-Control</xsl:attribute>
    <table width="100%" height="100%" border="0" class="Common-FontData ScheduleBox-MonthTable" cellpadding="0" cellspacing="0">
      <xsl:if test="@DisplayMonthHeader='True'">
        <xsl:attribute name="vwg_month">
          <xsl:value-of select="@CurrentMonthHeader" />
        </xsl:attribute>
        <tr class="ScheduleBox-Header">
          <td class="ScheduleBox-HeaderLabel" colspan="6" align="center">
            <xsl:value-of select="@CurrentMonthHeader" />
          </td>
        </tr>
      </xsl:if>
      <tr class="ScheduleBox-Header">
        <xsl:if test="@DisplatFirstWeekDay=1"><td class="ScheduleBox-HeaderLabel" align="center">Labels.Sunday</td></xsl:if>
        <td class="ScheduleBox-HeaderLabel" align="center">Labels.Monday</td>
        <td class="ScheduleBox-HeaderLabel" align="center">Labels.Tuesday</td>
        <td class="ScheduleBox-HeaderLabel" align="center">Labels.Wednesday</td>
        <td class="ScheduleBox-HeaderLabel" align="center">Labels.Thursday</td>
        <xsl:if test="@DisplatFirstWeekDay=1">       
          <td class="ScheduleBox-HeaderLabel" align="center" style="border-right:none">Labels.Friday/Labels.Saturday</td>
        </xsl:if>
        <xsl:if test="@DisplatFirstWeekDay=2">
          <td class="ScheduleBox-HeaderLabel" align="center">Labels.Friday</td>        
          <td class="ScheduleBox-HeaderLabel" align="center" style="border-right:none">Labels.Saturday/Labels.Sunday</td>
        </xsl:if>
      </tr>
      <xsl:call-template name="tplScheduleBoxDrawMonthWeeks" />
    </table>
  </xsl:template>

  <xsl:template name="tplScheduleBoxDrawMonthWeeks">
    <xsl:param name="prmWeek" select="6" />
    <xsl:param name="prmWeekIndex" select="6-$prmWeek" />
    <tr>
      <xsl:call-template name="tplScheduleBoxDrawMonthDays">
        <xsl:with-param name="prmWeekIndex" select="$prmWeekIndex" />
      </xsl:call-template>
      <td style="border-right:none">
        <xsl:call-template name="tplScheduleBoxDrawMonthDay">
          <xsl:with-param name="prmDayIndex" select="($prmWeekIndex*7)+6" />
        </xsl:call-template>
      </td>
    </tr>
    <tr>
      <td style="border-right:none">
        <xsl:call-template name="tplScheduleBoxDrawMonthDay">
          <xsl:with-param name="prmDayIndex" select="($prmWeekIndex*7)+7" />
        </xsl:call-template>
      </td>
    </tr>
    <xsl:if test="$prmWeek &gt; 1">
      <xsl:call-template name="tplScheduleBoxDrawMonthWeeks">
        <xsl:with-param name="prmWeek" select="number($prmWeek)-1" />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplScheduleBoxDrawMonthDays">
    <xsl:param name="prmDay" select="5" />
    <xsl:param name="prmWeekIndex" select="0" />   
    <td rowspan="2"><xsl:call-template name="tplScheduleBoxDrawMonthDay"><xsl:with-param name="prmDayIndex" select="($prmWeekIndex*7)+(5-$prmDay)+1" /></xsl:call-template></td>
    <xsl:if test="$prmDay &gt; 1">
      <xsl:call-template name="tplScheduleBoxDrawMonthDays">
        <xsl:with-param name="prmDay" select="number($prmDay)-1" />
        <xsl:with-param name="prmWeekIndex" select="$prmWeekIndex" />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  
  <xsl:template name="tplScheduleBoxDrawMonthDay">
    <xsl:param name="prmDayIndex" /> 
    <xsl:param name="prmMonthDay" select="@DisplayStart &lt;= $prmDayIndex and @DisplayStart+@DisplayDays &gt; $prmDayIndex" />
    <xsl:param name="prmScheduleId" select="@Id" />
    <xsl:attribute name="valign">top</xsl:attribute>
    <xsl:if test="$prmMonthDay">
      <xsl:variable name="dayIndex" select="$prmDayIndex - @DisplayStart + 1" />
		<xsl:for-each select="Day[@Number=$dayIndex and @IsToday and @IsToday='1']">
        <xsl:attribute name="style">border:2px solid red;</xsl:attribute>
      </xsl:for-each>
      <xsl:attribute name="class">ScheduleBox-Background_0</xsl:attribute>

      <!--jrt onclick-->
      <xsl:attribute name="vwg_day">
        <xsl:value-of select="$prmDayIndex - @DisplayStart + 1" />
      </xsl:attribute>
      <xsl:attribute name="onclick">ScheduleBox_RowClick(event,<xsl:value-of select="@Attr.Id"/>,this,'m')</xsl:attribute>
      
      <div class="ScheduleBox-MonthDate" align="{$right}" DisplayStart="{@DisplayStart}"  DayIndex="{$prmDayIndex}"><xsl:value-of select="$prmDayIndex - @DisplayStart + 1" /></div>
      <xsl:for-each select="Row">
        <xsl:call-template name="tplScheduleBoxDrawAllDayEventsForMonthView">
          <xsl:with-param name="prmDayIndex" select="$dayIndex"></xsl:with-param>
          <xsl:with-param name="prmScheduleId" select="ancestor::WC:Tags.ScheduleBox/@Id" />
        </xsl:call-template>
      </xsl:for-each>
		<xsl:for-each select="Day[@Number = $dayIndex]">
          <xsl:for-each select="Event">
            <div vwgevents="{@Attr.Events}" id="VWG_{$prmScheduleId}_{@Attr.MemberID}" onclick="mobjApp.ScheduleBox_Click(this.id,window,event);" ondblclick="mobjApp.ScheduleBox_DoubleClick(this.id,window,event);" class="ScheduleBox-MonthEvent" onmouseover="javascript: this.style.cursor='pointer';" title="{@Subject}" align="center">
              <!--<xsl:if test="string-length(@Subject) &gt; 10">
                <xsl:value-of select="substring(@Subject,1,10)" />...
              </xsl:if>
              <xsl:if test="string-length(@Subject) &lt; 11">
                <xsl:value-of select="@Subject" />
              </xsl:if>-->
              <xsl:value-of select="@Subject" />
            </div>
          </xsl:for-each>
        </xsl:for-each>
    </xsl:if>
    <xsl:if test="not($prmMonthDay)">
      <xsl:attribute name="class">ScheduleBox-Background_1</xsl:attribute>
    </xsl:if>
     
  </xsl:template>
  
  <xsl:template name="tplScheduleBoxDrawAllDayEventsForMonthView">
    <xsl:param name="prmDayIndex" />
    <xsl:param name="prmScheduleId" />
    <xsl:for-each select="Event">
      <xsl:if test="@Start &lt;= $prmDayIndex and @Start+@Duration &gt; $prmDayIndex">        
        <div vwgevents="{@Attr.Events}" id="VWG_{$prmScheduleId}_{@Attr.MemberID}" onclick="mobjApp.ScheduleBox_Click(this.id,window,event);" ondblclick="mobjApp.ScheduleBox_DoubleClick(this.id,window,event);" class="ScheduleBox-MonthEvent" onmouseover="javascript: this.style.cursor='pointer';" title="{@Subject}" align="center">
          <xsl:if test="string-length(@Subject) &gt; 10">
            <xsl:value-of select="substring(@Subject,1,10)" />...
          </xsl:if>
          <xsl:if test="string-length(@Subject) &lt; 11">
            <xsl:value-of select="@Subject" />
          </xsl:if>
        </div>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>
  
  <xsl:template match="WC:Tags.ScheduleBox[@Attr.View='Days']" mode="modContent">
    <xsl:attribute name="class">ScheduleBox-Control</xsl:attribute>	
    <div class="ScheduleBox-Scroller">
      <table class="ScheduleBox-Table" width="100%" border="0" cellpadding="0" cellspacing="0">
        <col class="ScheduleBox-TimeRowHeaderBorderColl" />
        <col class="ScheduleBox-TimeRowHeaderColl" />
        <col class="ScheduleBox-TimeRowHeaderBorderColl" />
        <xsl:for-each select="Day">
          <col class="ScheduleBox-DaySeparatorColl" />
          <col />
        </xsl:for-each>
        <xsl:if test="@DisplayMonthHeader='True'">
          <xsl:if test="@FullMonth='Yes'">
            <tr class="ScheduleBox-Header">
              <td colspan="2"> </td>
              <td class="ScheduleBox-TimeRowHeader_1"></td>
              <xsl:for-each select="Month">
                <td class="ScheduleBox-HeaderLabel" colspan="{@MonthDays*2}" align="middle">
                  <span class="Common-FontData ScheduleBox-MonthTable">
                    <xsl:value-of select="@MonthHeader" />
                  </span>
                </td>
              </xsl:for-each>
            </tr>
          </xsl:if>
        </xsl:if>
        <tr>          
          <td rowspan="{1+count(Row)}" class="ScheduleBox-TimeRowHeader_0"></td>
          <td rowspan="{1+count(Row)}" class="Common-FontTitle ScheduleBox-TimeRowHeader" align="right" valign="top">
             
          </td>
          <td rowspan="{1+count(Row)}" class="ScheduleBox-TimeRowHeader_1"></td>
          <xsl:for-each select="Day">
            <td class="ScheduleBox-Header" colspan="2" valign="top">
              <div class="Common-Strech Common-FontData ScheduleBox-HeaderLabel" align="center">
                <nobr>
                  <xsl:call-template name="tplDecodeTextAsHtml">
                    <xsl:with-param name="prmText" select="@Attr.Title" />
                  </xsl:call-template> 
                </nobr>
              </div>
            </td>
          </xsl:for-each>
        </tr>
        <xsl:for-each select="Row">
          <xsl:call-template name="tplScheduleBoxDrawAllDayEvents" />
        </xsl:for-each>
        <xsl:call-template name="tplScheduleBoxDrawTimeRows" />
      </table>
    </div>
  </xsl:template>

  <xsl:template name="tplScheduleBoxDrawTimeRows">
    <xsl:param name="prmIndex" select="0" />
    <xsl:choose>
      <xsl:when test="not(@WorkStartHour)">
        <xsl:call-template name="tplScheduleBoxDrawAllDayEventsHours">
          <xsl:with-param name="prmIndex" select="$prmIndex" />
          <xsl:with-param name="prmWorkStartHour" select="8"></xsl:with-param>
          <xsl:with-param name="prmWorkEndHour" select="17"></xsl:with-param>
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <xsl:call-template name="tplScheduleBoxDrawAllDayEventsHours">
          <xsl:with-param name="prmIndex" select="$prmIndex" />
          <xsl:with-param name="prmWorkStartHour" select="@WorkStartHour"></xsl:with-param>
          <xsl:with-param name="prmWorkEndHour" select="@WorkEndHour"></xsl:with-param>
        </xsl:call-template>        
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <xsl:template name="tplScheduleBoxDrawAllDayEventsHours">
    <xsl:param name="prmWorkStartHour" />
    <xsl:param name="prmWorkEndHour" />
    <xsl:param name="prmIndex" />
    <xsl:param name="prmWork" select="number($prmIndex &gt; $prmWorkStartHour and $prmIndex &lt;= $prmWorkEndHour)" />
    <tr style="height:[Skin.HalfHourHeight]px">
      <td rowspan="2" class="ScheduleBox-TimeRowHeader_0"></td>
      <td rowspan="2" class="ScheduleBox-FontTitle ScheduleBox-TimeRowHeader" align="right" valign="top">
        <xsl:if test="@HourFormat='Clock12H'">
          <xsl:choose>
            <xsl:when test="$prmIndex=0">
              12<sup>am</sup>
            </xsl:when>
            <xsl:when test="$prmIndex=12">
              12<sup>pm</sup>
            </xsl:when>
            <xsl:when test="$prmIndex &gt; 12">
              <xsl:value-of select="number($prmIndex)-12" />
              <sup>00</sup>
            </xsl:when>
            <xsl:otherwise>
              <xsl:value-of select="$prmIndex" />
              <sup>00</sup>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:if>
        <xsl:if test="@HourFormat='Clock24H'">
          <xsl:value-of select="$prmIndex" />
          <sup>00</sup>
        </xsl:if> 
      </td>
      <td rowspan="2" class="ScheduleBox-TimeRowHeader_1"></td>
      <xsl:for-each select="Day">
        <xsl:if test="$prmIndex='0'">
          <td class="ScheduleBox-TimeGridCell" rowspan="48">
            <xsl:if test="position()&gt;1">
              <xsl:attribute name="style">border-left:1px solid black;</xsl:attribute>
            </xsl:if>
             
          </td>
        </xsl:if>
        <td class="ScheduleBox-Background_{$prmWork} ScheduleBox-TimeRowCellA" onclick="ScheduleBox_RowClick(event,{../@Attr.Id},this,'wA')">
          <xsl:call-template name="tplScheduleBoxDrawTimeRowEvents">
            <xsl:with-param name="prmIndex" select="$prmIndex*2" />
          </xsl:call-template> 
        </td>
      </xsl:for-each>
    </tr>
    <tr style="height:[Skin.HalfHourHeight]px">
      <xsl:for-each select="Day">
        <td class="ScheduleBox-Background_{$prmWork} ScheduleBox-TimeRowCellB" onclick="ScheduleBox_RowClick(event,{../@Attr.Id},this,'wB')">
          <xsl:call-template name="tplScheduleBoxDrawTimeRowEvents">
            <xsl:with-param name="prmIndex" select="$prmIndex*2+1" />
          </xsl:call-template> 
        </td>
      </xsl:for-each>
    </tr>
    <xsl:if test="$prmIndex &lt; 23">
      <xsl:call-template name="tplScheduleBoxDrawTimeRows">
        <xsl:with-param name="prmIndex" select="$prmIndex+1" />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

  <xsl:template name="tplScheduleBoxDrawTimeRowEvents">
    <xsl:param name="prmScheduleId" select="ancestor::WC:Tags.ScheduleBox/@Id" />
    <xsl:param name="prmIndex" />
    <div>
      <xsl:if test="Event[@Start=$prmIndex]">
        <xsl:attribute name="style">position:relative;overflow:visible;</xsl:attribute>
      </xsl:if>
      <xsl:for-each select="Event[@Start=$prmIndex]">
        <div id="VWG_{$prmScheduleId}_{@Attr.MemberID}" vwgevents="{@Attr.Events}" onclick="mobjApp.ScheduleBox_Click(this.id,window,event);" ondblclick="mobjApp.ScheduleBox_DoubleClick(this.id,window,event);" class="Common-FontData" onmouseover="javascript: this.style.cursor='pointer';" title="{@Subject}">          
          <xsl:attribute name="style">
            overflow: visible; position:absolute;padding-right:3px;width:<xsl:value-of select="100 div @Share" />%;left:<xsl:value-of select="(100 div @Share) * @Left" />%;height:<xsl:value-of select="@Duration * [Skin.HalfHourHeight]" />px;
            <xsl:if test="@Attr.OffsetY">top:<xsl:value-of select="@Attr.OffsetY" />px;</xsl:if>
          </xsl:attribute>
          <div class="ScheduleBox-EventBG">
            <div class="ScheduleBox-Event">
               <xsl:value-of select="@Subject" />
            </div>
          </div>
        </div>
      </xsl:for-each>
    </div>
  </xsl:template>

  <xsl:template name="tplScheduleBoxDrawAllDayEvents">
    <xsl:param name="prmIndex" select="0" />
    <xsl:param name="prmRow" select="." />
    <xsl:param name="prmScheduleId" select="ancestor::WC:Tags.ScheduleBox/@Id" />
    <tr>
      <xsl:for-each select="../Day">
        <xsl:variable name="prmPosition" select="position()" />
        <xsl:choose>
          <xsl:when test="$prmRow/Event[@Start=$prmPosition]">
            <td class="ScheduleBox-HeaderEvents">
			        <xsl:attribute name="colspan"><xsl:value-of select="$prmRow/Event[@Start=$prmPosition]/@Duration*2" /></xsl:attribute>
              <xsl:if test="$prmPosition&gt;1">
                <xsl:attribute name="style">border-left:1px solid black;</xsl:attribute>
              </xsl:if>
              <div class="Common-FontData ScheduleBox-AllDayEvent" onclick="mobjApp.ScheduleBox_Click(this.id,window,event);" ondblclick="mobjApp.ScheduleBox_DoubleClick(this.id,window,event);" onmouseover="javascript: this.style.cursor='pointer';">
                <xsl:attribute name="vwgevents"><xsl:value-of select="$prmRow/Event[@Start=$prmPosition]/@Attr.Events" /></xsl:attribute>
				        <xsl:attribute name="id">VWG_<xsl:value-of select="$prmScheduleId" />_<xsl:value-of select="$prmRow/Event[@Start=$prmPosition]/@Attr.MemberID" /></xsl:attribute>
				        <xsl:attribute name="title"><xsl:value-of select="$prmRow/Event[@Start=$prmPosition]/@Subject" /></xsl:attribute>
                <nobr>
                  <xsl:value-of select="$prmRow/Event[@Start=$prmPosition]/@Subject" /> 
                </nobr>
              </div>
            </td>
          </xsl:when>
          <xsl:when test="not($prmRow/Event[@Start &lt; $prmPosition and (@Start+@Duration) &gt; $prmPosition])">
            <td class="ScheduleBox-HeaderEvents" colspan="2">
              <xsl:if test="position()&gt;1">
                <xsl:attribute name="style">border-left:1px solid black;</xsl:attribute>
              </xsl:if> 
            </td>
          </xsl:when>
        </xsl:choose>

      </xsl:for-each>
    </tr>
  </xsl:template>
</xsl:stylesheet>

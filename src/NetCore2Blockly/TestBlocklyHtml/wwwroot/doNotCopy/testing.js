//if you want to copy those blocks, make sure you replace \` with `
var testBlocks = [
    {
        name: 'save image',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="^HqtU]3:/R^Xs!?,#:]m">n</variable>
        <variable id="f~YJqnSTlX^GoI/nN*h~">nameFile</variable>
        <variable id=",QS2XTKZ]7gJZ_KB#gQ_">imgContent</variable>
    </variables>
    <block type="variables_set" y="46" x="-535" inline="true">
        <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
        <value name="VALUE">
            <block type="api_TestImage_GetImageSprite_GET"></block>
        </value>
        <next>
            <block type="variables_set">
                <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                <value name="VALUE">
                    <block type="converttojson">
                        <value name="ValueToConvert">
                            <block type="variables_get">
                                <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                            </block>
                        </value>
                    </block>
                </value>
                <next>
                    <block type="variables_set">
                        <field id="f~YJqnSTlX^GoI/nN*h~" name="VAR">nameFile</field>
                        <value name="VALUE">
                            <block type="getproperty">
                                <field name="objectName">object</field>
                                <field name="prop">property</field>
                                <value name="ObjectToChange">
                                    <block type="variables_get"><field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                                    </block>
                                </value>
                                <value name="PropertyName">
                                    <block type="text"><field name="TEXT">name</field>
                                    </block>
                                </value>
                            </block>
                        </value>
                        <next>
                            <block type="variables_set">
                                <field id=",QS2XTKZ]7gJZ_KB#gQ_" name="VAR">imgContent</field>
                                <value name="VALUE">
                                    <block type="getproperty"><field name="objectName">object</field><field name="prop">property</field><value name="ObjectToChange"><block type="variables_get"><field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                                            </block>
                                        </value>
                                        <value name="PropertyName">
                                            <block type="text"><field name="TEXT">image</field>
                                            </block>
                                        </value>
                                    </block>
                                </value>
                                <next>
                                    <block type="text_print">
                                        <value name="TEXT">
                                            <shadow type="text"><field name="TEXT">abc</field>
                                            </shadow>
                                            <block type="variables_get"><field id="f~YJqnSTlX^GoI/nN*h~" name="VAR">nameFile</field>
                                            </block>
                                        </value>
                                        <next>
                                            <block type="text_print"><value name="TEXT"><shadow type="text"><field name="TEXT">abc</field>
                                                    </shadow>
                                                    <block type="variables_get"><field id=",QS2XTKZ]7gJZ_KB#gQ_" name="VAR">imgContent</field>
                                                    </block>
                                                </value>
                                                <next>
                                                    <block type="exportfile"><value name="fileName"><shadow type="text"><field name="TEXT">abc</field>
                                                            </shadow>
                                                            <block type="variables_get"><field id="f~YJqnSTlX^GoI/nN*h~" name="VAR">nameFile</field>
                                                            </block>
                                                        </value>
                                                        <value name="contentFile">
                                                            <block type="variables_get"><field id=",QS2XTKZ]7gJZ_KB#gQ_" name="VAR">imgContent</field>
                                                            </block>
                                                        </value>
                                                        <value name="convertToByte">
                                                            <shadow type="logic_boolean"><field name="BOOL">TRUE</field>
                                                            </shadow>
                                                        </value>
                                                    </block>
                                                </next>
                                            </block>
                                        </next>
                                    </block>
                                </next>
                            </block>
                        </next>
                    </block>
                </next>
            </block>
        </next>
    </block>
</xml>`
    },
    {
        name: 'save csv as file',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="^HqtU]3:/R^Xs!?,#:]m">n</variable>
    </variables>
    <block type="variables_set" y="52" x="-71" inline="true">
        <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
        <value name="VALUE">
            <block type="WeatherForecast_GET"></block>
        </value>
        <next>
            <block type="text_print">
                <value name="TEXT">
                    <shadow type="text">
                        <field name="TEXT">abc</field>
                    </shadow>
                    <block type="variables_get">
                        <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                    </block>
                </value>
                <next>
                    <block type="variables_set" inline="true">
                        <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                        <value name="VALUE">
                            <block type="convertcsv">
                                <value name="ArrayToConvert">
                                    <block type="WeatherForecast_GET"></block>
                                </value>
                            </block>
                        </value>
                        <next>
                            <block type="text_print">
                                <value name="TEXT">
                                    <shadow type="text"><field name="TEXT">abc</field>
                                    </shadow>
                                    <block type="variables_get"><field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                                    </block>
                                </value>
                                <next>
                                    <block type="exportfile"><value name="fileName"><shadow type="text"><field name="TEXT">khgjg.csv</field>
                                            </shadow>
                                        </value>
                                        <value name="contentFile">
                                            <block type="variables_get"><field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                                            </block>
                                        </value>
                                        <value name="convertToByte">
                                            <shadow type="logic_boolean"><field name="BOOL">FALSE</field>
                                            </shadow>
                                        </value>
                                    </block>
                                </next>
                            </block>
                        </next>
                    </block>
                </next>
            </block>
        </next>
    </block>
</xml>`
    },
    {
        name: 'convert csv',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="^HqtU]3:/R^Xs!?,#:]m">n</variable>
    </variables>
    <block type="variables_set" y="20" x="20" inline="true">
        <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
        <value name="VALUE">
            <block type="WeatherForecast_GET"></block>
        </value>
        <next>
            <block type="text_print">
                <value name="TEXT">
                    <shadow type="text">
                        <field name="TEXT">abc</field>
                    </shadow>
                    <block type="variables_get">
                        <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                    </block>
                </value>
                <next>
                    <block type="variables_set" inline="true">
                        <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                        <value name="VALUE">
                            <block type="convertcsv">
                                <value name="ArrayToConvert">
                                    <block type="WeatherForecast_GET"></block>
                                </value>
                            </block>
                        </value>
                        <next>
                            <block type="text_print">
                                <value name="TEXT">
                                    <shadow type="text"><field name="TEXT">abc</field>
                                    </shadow>
                                    <block type="variables_get"><field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                                    </block>
                                </value>
                            </block>
                        </next>
                    </block>
                </next>
            </block>
        </next>
    </block>
</xml>`
    },
    {
        name: 'modify prop',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="}N:3#8}TL(iEuP8oCY6A">n</variable>
        <variable id="Ro;$Xw+OPUiM_p0j!8oQ">var_Math2Values</variable>
    </variables>
    <block type="variables_set" y="68" x="55" inline="true">
        <field id="}N:3#8}TL(iEuP8oCY6A" name="VAR">n</field>
        <value name="VALUE">
            <block type="math_number">
                <field name="NUM">1</field>
            </block>
        </value>
        <next>
            <block type="variables_set">
                <field id="Ro;$Xw+OPUiM_p0j!8oQ" name="VAR">var_Math2Values</field>
                <value name="VALUE">
                    <block type="TestBlocklyHtml_Math2Values">
                        <value name="val_x">
                            <shadow type="math_number">
                                <field name="NUM">10</field>
                            </shadow>
                        </value>
                        <value name="val_y">
                            <shadow type="math_number">
                                <field name="NUM">10</field>
                            </shadow>
                        </value>
                    </block>
                </value>
                <next>
                    <block type="text_print">
                        <value name="TEXT">
                            <shadow type="text">
                                <field name="TEXT">abc</field>
                            </shadow>
                            <block type="converttostring">
                                <value name="ValueToConvert">
                                    <block type="variables_get"><field id="Ro;$Xw+OPUiM_p0j!8oQ" name="VAR">var_Math2Values</field>
                                    </block>
                                </value>
                            </block>
                        </value>
                        <next>
                            <block type="modifyproperty">
                                <field name="objectName">object</field>
                                <field name="prop">,property</field>
                                <field name="newValue">toValue</field>
                                <value name="ObjectToChange">
                                    <block type="variables_get"><field id="Ro;$Xw+OPUiM_p0j!8oQ" name="VAR">var_Math2Values</field>
                                    </block>
                                </value>
                                <value name="PropertyName">
                                    <block type="text"><field name="TEXT">x</field>
                                    </block>
                                </value>
                                <value name="NewValue">
                                    <block type="variables_get"><field id="}N:3#8}TL(iEuP8oCY6A" name="VAR">n</field>
                                    </block>
                                </value>
                                <next>
                                    <block type="text_print"><value name="TEXT"><shadow type="text"><field name="TEXT">abc</field>
                                            </shadow>
                                            <block type="converttostring"><value name="ValueToConvert"><block type="variables_get"><field id="Ro;$Xw+OPUiM_p0j!8oQ" name="VAR">var_Math2Values</field>
                                                    </block>
                                                </value>
                                            </block>
                                        </value>
                                    </block>
                                </next>
                            </block>
                        </next>
                    </block>
                </next>
            </block>
        </next>
    </block>
</xml>`},
    {

        name: 'Just weather',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
  <variables>
    <variable id="^HqtU]3:/R^Xs!?,#:]m">n</variable>
  </variables>
  <block type="variables_set" id="set_n_initial" inline="true" x="20" y="20">
    <field name="VAR" id="^HqtU]3:/R^Xs!?,#:]m">n</field>
    <value name="VALUE">
      <block type="math_number" id="^+AKjl[KXHWUX=n4}L?7">
        <field name="NUM">1</field>
      </block>
    </value>
    <next>
      <block type="text_print" id="xz}Huefk:Dt]#0_C:c1Y">
        <value name="TEXT">
          <shadow type="text" id="xJ*x^7]_RVDjH|+2d~+t">
            <field name="TEXT">abc</field>
          </shadow>
          <block type="WeatherForecast_GET" id="BR+qr5jpf,neGJCluvdG"></block>
        </value>
      </block>
    </next>
  </block>
</xml>`
    },
    {
        name: 'Get items from GET REST call',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="^HqtU]3:/R^Xs!?,#:]m">n</variable>
        <variable id="^Aegl%=)*Nuw/F?C7ll)">list</variable>
        <variable id="43omA)lH5]@xKx#LjSes">var_Math2Values</variable>
    </variables>
    <block id="set_n_initial" type="variables_set" y="20" x="20" inline="true">
        <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
        <value name="VALUE">
            <block id="^+AKjl[KXHWUX=n4}L?7" type="math_number">
                <field name="NUM">1</field>
            </block>
        </value>
        <next>
            <block id="c~swCYe|6)jElY;-+,l}" type="variables_set">
                <field id="^Aegl%=)*Nuw/F?C7ll)" name="VAR">list</field>
                <value name="VALUE">
                    <block id="8Iv-:.Ip6r*_2^^BX(mm" type="converttojson">
                        <value name="ValueToConvert">
                            <block id="Lcy-?cJK?g7Xs^mc#Ie," type="api_MathDivideRest_GET"></block>
                        </value>
                    </block>
                </value>
                <next>
                    <block id="[)USsB,B\`qB[NdJ1evx5" type="variables_set">
                        <field id="43omA)lH5]@xKx#LjSes" name="VAR">var_Math2Values</field>
                        <value name="VALUE">
                            <block id="6Nfdpv\`*eib63*oVNBhL" type="lists_getIndex">
                                <mutation at="false" statement="false"></mutation>
                                <field name="MODE">GET</field>
                                <field name="WHERE">FIRST</field>
                                <value name="VALUE">
                                    <block id="i4vKSFy_r~.x=jsS5;cZ" type="variables_get"><field id="^Aegl%=)*Nuw/F?C7ll)" name="VAR">list</field>
                                    </block>
                                </value>
                            </block>
                        </value>
                        <next>
                            <block id="xz}Huefk:Dt]#0_C:c1Y" type="text_print">
                                <value name="TEXT">
                                    <shadow id="xJ*x^7]_RVDjH|+2d~+t" type="text"><field name="TEXT">abc</field>
                                    </shadow>
                                    <block id="xp5mAs-^NzC]tu:]1m0A" type="converttostring"><value name="ValueToConvert"><block id="v{N}]+au@VA]9COZqw{|" type="variables_get"><field id="43omA)lH5]@xKx#LjSes" name="VAR">var_Math2Values</field>
                                            </block>
                                        </value>
                                    </block>
                                </value>
                                <next>
                                    <block id="GvUbg?W^1qmPj;:$P_F\`" type="variables_set">
                                        <field id="43omA)lH5]@xKx#LjSes" name="VAR">var_Math2Values</field>
                                        <value name="VALUE">
                                            <block id="6h5/n5Ec;;6:RIg3l!5h" type="lists_getIndex"><mutation at="false" statement="false"></mutation><field name="MODE">GET</field><field name="WHERE">LAST</field><value name="VALUE"><block id="3yIr7rs9Ps7_zhFiWyn=" type="variables_get"><field id="^Aegl%=)*Nuw/F?C7ll)" name="VAR">list</field>
                                                    </block>
                                                </value>
                                            </block>
                                        </value>
                                        <next>
                                            <block id="?tD+4;B.SN[#=](AU/LE" type="text_print">
                                                <value name="TEXT">
                                                    <shadow type="text"><field name="TEXT">abc</field>
                                                    </shadow>
                                                    <block id="=EQr_hqJ4N2-48j!oUn8" type="converttostring"><value name="ValueToConvert"><block id="Ow[J+$g3\`R8(qhg/Rgj4" type="variables_get"><field id="43omA)lH5]@xKx#LjSes" name="VAR">var_Math2Values</field>
                                                            </block>
                                                        </value>
                                                    </block>
                                                </value>
                                            </block>
                                        </next>
                                    </block>
                                </next>
                            </block>
                        </next>
                    </block>
                </next>
            </block>
        </next>
    </block>
</xml>`
    },
    {
        name: 'Get and Post',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="^HqtU]3:/R^Xs!?,#:]m">n</variable>
        <variable id="43omA)lH5]@xKx#LjSes">var_Math2Values</variable>
    </variables>
    <block id="set_n_initial" type="variables_set" y="20" x="20" inline="true">
        <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
        <value name="VALUE">
            <block id="^+AKjl[KXHWUX=n4}L?7" type="math_number">
                <field name="NUM">90</field>
            </block>
        </value>
        <next>
            <block id="nk~N#rsu:5QG!e4gxhme" type="variables_set">
                <field id="43omA)lH5]@xKx#LjSes" name="VAR">var_Math2Values</field>
                <value name="VALUE">
                    <block id="lt7v_nQ5KX0)v-8DF!H]" type="converttojson">
                        <value name="ValueToConvert">
                            <block id="eS?yCGb}./iFL?fB4,~=" type="api_MathDivideRest__id__GET">
                                <value name="val_id">
                                    <shadow id="UcBEM8\`0J-gNi|INftgm" type="math_number"><field name="NUM">10</field>
                                    </shadow>
                                    <block id="~XYK(H)g|koScok3-!a@" type="variables_get"><field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                                    </block>
                                </value>
                            </block>
                        </value>
                    </block>
                </value>
                <next>
                    <block id="UD*]u%TzE2T[?[w|mYsJ" type="text_print">
                        <value name="TEXT">
                            <shadow id="Cnq%+v{xRUh[zM{n2T-[" type="text">
                                <field name="TEXT">abc</field>
                            </shadow>
                            <block id="rC1jdsCbZT=T?=iyyhC$" type="converttostring">
                                <value name="ValueToConvert">
                                    <block id="I_QjjCFVe%F[SVDSbl;_" type="variables_get"><field id="43omA)lH5]@xKx#LjSes" name="VAR">var_Math2Values</field>
                                    </block>
                                </value>
                            </block>
                        </value>
                        <next>
                            <block id="S*YAhIdY3UIf!lxOIl#|" type="variables_set" inline="true">
                                <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                                <value name="VALUE">
                                    <block id="#LQ):*eTN,9ZeyppGw\`$" type="api_MathDivideRest_POST"><value name="val_values"><shadow id="uu8h,,H=];uz$mUZ-:)h" type="TestBlocklyHtml_Math2Values"></shadow><block id="$d;8$Ry*D-=CPj@S-I0?" type="variables_get"><field id="43omA)lH5]@xKx#LjSes" name="VAR">var_Math2Values</field>
                                            </block>
                                        </value>
                                    </block>
                                </value>
                                <next>
                                    <block id="1VW?m?|iKHE$U]1!6RIY" type="text_print">
                                        <value name="TEXT">
                                            <shadow id="|F}]ve!mpnRb*ln;h5IQ" type="text"><field name="TEXT">abc</field>
                                            </shadow>
                                            <block id="7S?u@L/]xoqsU.j!CT.k" type="variables_get"><field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                                            </block>
                                        </value>
                                    </block>
                                </next>
                            </block>
                        </next>
                    </block>
                </next>
            </block>
        </next>
    </block>
    <block id="t.KZiVh]u/.Iy/xcLkOL" type="math_number" y="191" x="149">
        <field name="NUM">90</field>
    </block>
</xml>`

    },
    {
        name: "Put & POST",
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable >n</variable>
        <variable >var_Math2Values</variable>
        <variable  type="TestBlocklyHtml_Math2Values">var_Math2Values</variable>
    </variables>
    <block id="set_n_initial" type="variables_set" y="-425" x="-598" inline="true">
        <field  name="VAR">n</field>
        <value name="VALUE">
            <block  type="math_number">
                <field name="NUM">90</field>
            </block>
        </value>
        <next>
            <block type="variables_set">
                <field name="VAR">var_Math2Values</field>
                <value name="VALUE">
                    <block type="TestBlocklyHtml_Math2Values">
                        <value name="val_x">
                            <shadow type="math_number">
                                <field name="NUM">10</field>
                            </shadow>
                            <block type="variables_get">
                                <field name="VAR">n</field>
                            </block>
                        </value>
                        <value name="val_y">
                            <shadow type="math_number">
                                <field name="NUM">10</field>
                            </shadow>
                        </value>
                    </block>
                </value>
                <next>
                    <block type="text_print">
                        <value name="TEXT">
                            <shadow type="text">
                                <field name="TEXT">abc</field>
                            </shadow>
                            <block type="converttostring">
                                <value name="ValueToConvert">
                                    <block type="variables_get"><field name="VAR">var_Math2Values</field>
                                    </block>
                                </value>
                            </block>
                        </value>
                        <next>
                            <block type="variables_set" inline="true">
                                <field name="VAR">n</field>
                                <value name="VALUE">
                                    <block  type="api_MathDivideRest_POST"><value name="val_values"><shadow type="TestBlocklyHtml_Math2Values"></shadow><block type="variables_get"><field name="VAR">var_Math2Values</field>
                                            </block>
                                        </value>
                                    </block>
                                </value>
                                <next>
                                    <block type="text_print">
                                        <value name="TEXT">
                                            <shadow type="text"><field name="TEXT">abc</field>
                                            </shadow>
                                            <block type="variables_get"><field name="VAR">n</field>
                                            </block>
                                        </value>
                                        <next>
                                            <block type="variables_set" inline="true"><field name="VAR" variabletype="TestBlocklyHtml_Math2Values">var_Math2Values</field><value name="VALUE"><block type="api_MathDivideRest__id__PUT"><value name="val_id"><shadow type="math_number"><field name="NUM">10</field>
                                                            </shadow>
                                                        </value>
                                                        <value name="val_values">
                                                            <shadow type="TestBlocklyHtml_Math2Values"></shadow>
                                                            <block type="variables_get"><field name="VAR">var_Math2Values</field>
                                                            </block>
                                                        </value>
                                                    </block>
                                                </value>
                                                <next>
                                                    <block  type="text_print">
                                                        <value name="TEXT">
                                                            <shadow type="text"><field name="TEXT">abc</field>
                                                            </shadow>
                                                            <block type="variables_get"><field name="VAR" variabletype="TestBlocklyHtml_Math2Values">var_Math2Values</field>
                                                            </block>
                                                        </value>
                                                        <next>
                                                            <block type="variables_set" inline="true"><field name="VAR" variabletype="TestBlocklyHtml_Math2Values">var_Math2Values</field><value name="VALUE"><block type="converttojson"><value name="ValueToConvert"><block type="variables_get"><field name="VAR">var_Math2Values</field>
                                                                            </block>
                                                                        </value>
                                                                    </block>
                                                                </value>
                                                                <next>
                                                                    <block type="variables_set" inline="true">
                                                                        <field name="VAR" variabletype="TestBlocklyHtml_Math2Values">var_Math2Values</field>
                                                                        <value name="VALUE">
                                                                            <block type="api_MathDivideRest__id__PUT"><value name="val_id"><shadow type="math_number"><field name="NUM">10</field>
                                                                                    </shadow>
                                                                                </value>
                                                                                <value name="val_values">
                                                                                    <shadow type="TestBlocklyHtml_Math2Values"></shadow>
                                                                                    <block type="variables_get"><field name="VAR">var_Math2Values</field>
                                                                                    </block>
                                                                                </value>
                                                                            </block>
                                                                        </value>
                                                                        <next>
                                                                            <block type="text_print">
                                                                                <value name="TEXT">
                                                                                    <shadow type="text"><field name="TEXT">abc</field>
                                                                                    </shadow>
                                                                                    <block type="variables_get"><field name="VAR" variabletype="TestBlocklyHtml_Math2Values">var_Math2Values</field>
                                                                                    </block>
                                                                                </value>
                                                                            </block>
                                                                        </next>
                                                                    </block>
                                                                </next>
                                                            </block>
                                                        </next>
                                                    </block>
                                                </next>
                                            </block>
                                        </next>
                                    </block>
                                </next>
                            </block>
                        </next>
                    </block>
                </next>
            </block>
        </next>
    </block>
</xml>`
    },
    {
        name: 'Dynamic delete',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="P{SqEl7dFn[MB{MvR:H:">n</variable>
    </variables>
    <block type="variables_set" y="-452" x="-732" inline="true">
        <field id="P{SqEl7dFn[MB{MvR:H:" name="VAR">n</field>
        <value name="VALUE">
            <block type="text_prompt_ext">
                <mutation type="TEXT"></mutation>
                <field name="TYPE">TEXT</field>
                <value name="TEXT">
                    <shadow type="text">
                        <field name="TEXT">Please give id to delete</field>
                    </shadow>
                </value>
            </block>
        </value>
        <next>
            <block type="text_print">
                <value name="TEXT">
                    <shadow type="text">
                        <field name="TEXT">Done</field>
                    </shadow>
                    <block type="variables_get">
                        <field id="P{SqEl7dFn[MB{MvR:H:" name="VAR">n</field>
                    </block>
                </value>
                <next>
                    <block type="text_print">
                        <value name="TEXT">
                            <shadow type="text">
                                <field name="TEXT">abc</field>
                            </shadow>
                            <block type="api_MathDivideRest__id__DELETE">
                                <value name="val_id">
                                    <shadow type="math_number"><field name="NUM">10</field>
                                    </shadow>
                                    <block type="variables_get"><field id="P{SqEl7dFn[MB{MvR:H:" name="VAR">n</field>
                                    </block>
                                </value>
                            </block>
                        </value>
                        <next>
                            <block type="text_print">
                                <value name="TEXT">
                                    <shadow type="text"><field name="TEXT">Done</field>
                                    </shadow>
                                    <block type="text_join"><mutation items="2"></mutation><value name="ADD0"><block type="text"><field name="TEXT">Done the delete with</field>
                                            </block>
                                        </value>
                                        <value name="ADD1">
                                            <block type="variables_get"><field id="P{SqEl7dFn[MB{MvR:H:" name="VAR">n</field>
                                            </block>
                                        </value>
                                    </block>
                                </value>
                            </block>
                        </next>
                    </block>
                </next>
            </block>
        </next>
    </block>
</xml>`
    },
    {
        name: ' multiply 2 values ',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="^HqtU]3:/R^Xs!?,#:]m">n</variable>
    </variables>
    <block type="variables_set" y="20" x="20" inline="true">
        <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
        <value name="VALUE">
            <block type="math_number">
                <field name="NUM">10</field>
            </block>
        </value>
        <next>
            <block type="text_print">
                <value name="TEXT">
                    <shadow type="text">
                        <field name="TEXT">abc</field>
                    </shadow>
                    <block type="api_MathOperations_Multiply__x___y__GET">
                        <value name="val_x">
                            <shadow type="math_number">
                                <field name="NUM">2</field>
                            </shadow>
                        </value>
                        <value name="val_y">
                            <shadow type="math_number">
                                <field name="NUM">10</field>
                            </shadow>
                            <block type="variables_get">
                                <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                            </block>
                        </value>
                    </block>
                </value>
            </block>
        </next>
    </block>
</xml>`

    },
    {
        name: 'Divide by 0',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="^HqtU]3:/R^Xs!?,#:]m">n</variable>
    </variables>
    <block type="variables_set" y="35" x="47" inline="true">
        <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
        <value name="VALUE">
            <block type="math_number">
                <field name="NUM">10</field>
            </block>
        </value>
        <next>
            <block type="variables_set" inline="true">
                <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                <value name="VALUE">
                    <block type="api_MathOperations_Divide_POST">
                        <value name="val_data">
                            <shadow type="TestBlocklyHtml_Math2Values"></shadow>
                            <block type="TestBlocklyHtml_Math2Values">
                                <value name="val_x">
                                    <shadow type="math_number"><field name="NUM">10</field>
                                    </shadow>
                                </value>
                                <value name="val_y">
                                    <shadow type="math_number"><field name="NUM">10</field>
                                    </shadow>
                                    <block type="variables_get"><field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                                    </block>
                                </value>
                            </block>
                        </value>
                    </block>
                </value>
                <next>
                    <block type="text_print">
                        <value name="TEXT">
                            <shadow type="text">
                                <field name="TEXT">abc</field>
                            </shadow>
                            <block type="text_join">
                                <mutation items="3"></mutation>
                                <value name="ADD0">
                                    <block type="text"><field name="TEXT">The result is</field>
                                    </block>
                                </value>
                                <value name="ADD1">
                                    <block type="variables_get"><field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                                    </block>
                                </value>
                                <value name="ADD2">
                                    <block type="text"><field name="TEXT">Now, what happens if we divide by 0?</field>
                                    </block>
                                </value>
                            </block>
                        </value>
                        <next>
                            <block type="variables_set" inline="true">
                                <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
                                <value name="VALUE">
                                    <block type="math_number"><field name="NUM">0</field>
                                    </block>
                                </value>
                            </block>
                        </next>
                    </block>
                </next>
            </block>
        </next>
    </block>
    <block type="math_number" y="97" x="146">
        <field name="NUM">0</field>
    </block>
</xml>`
    }
    ,
    {
        name: 'https://github.com/ignatandrei/NETCoreBlockly/issues/12',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="^HqtU]3:/R^Xs!?,#:]m">n</variable>
    </variables>
    <block type="variables_set" y="20" x="20" inline="true">
        <field id="^HqtU]3:/R^Xs!?,#:]m" name="VAR">n</field>
        <value name="VALUE">
            <block type="math_number">
                <field name="NUM">10</field>
            </block>
        </value>
        <next>
            <block type="text_print">
                <value name="TEXT">
                    <shadow type="text">
                        <field name="TEXT">abc</field>
                    </shadow>
                    <block type="api_MathOperations_Add_POST">
                        <value name="val_data">
                            <shadow type="TestBlocklyHtml_Math2Values"></shadow>
                            <block type="TestBlocklyHtml_Math2Values">
                                <value name="val_x">
                                    <shadow type="math_number"><field name="NUM">10</field>
                                    </shadow>
                                </value>
                                <value name="val_y">
                                    <shadow type="math_number"><field name="NUM">10</field>
                                    </shadow>
                                </value>
                            </block>
                        </value>
                    </block>
                </value>
            </block>
        </next>
    </block>
    <block type="api_MathDivideRest_GET" y="182" x="189"></block>
    <block type="TestBlocklyHtml_Math2Values" y="215" x="68">
        <value name="val_x">
            <shadow type="math_number">
                <field name="NUM">2</field>
            </shadow>
        </value>
        <value name="val_y">
            <shadow type="math_number">
                <field name="NUM">4</field>
            </shadow>
        </value>
    </block>
</xml>`
    },
    {
        name: 'DB create new Department',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="P|b0sa?k$1vcEdVj!+fn">n</variable>
        <variable id="5;47gpsWUe91G}.~H]Om">var_Int64</variable>
        <variable id="nIdI=p;YaqO~NJ428@8h">var_Department</variable>
    </variables>
    <block type="variables_set" y="-195" x="-315" inline="true">
        <field id="P|b0sa?k$1vcEdVj!+fn" name="VAR">n</field>
        <value name="VALUE">
            <block type="text_prompt_ext">
                <mutation type="TEXT"></mutation>
                <field name="TYPE">TEXT</field>
                <value name="TEXT">
                    <shadow type="text">
                        <field name="TEXT">Please give name of the new Department</field>
                    </shadow>
                </value>
            </block>
        </value>
        <next>
            <block type="variables_set">
                <field id="5;47gpsWUe91G}.~H]Om" name="VAR">var_Int64</field>
                <value name="VALUE">
                    <block type="math_number">
                        <field name="NUM">23</field>
                    </block>
                </value>
                <next>
                    <block type="variables_set">
                        <field id="nIdI=p;YaqO~NJ428@8h" name="VAR">var_Department</field>
                        <value name="VALUE">
                            <block type="TestBlocklyHtml_DB_Department">
                                <value name="val_Iddepartment">
                                    <block type="variables_get"><field id="5;47gpsWUe91G}.~H]Om" name="VAR">var_Int64</field>
                                    </block>
                                </value>
                                <value name="val_Name">
                                    <shadow type="text"><field name="TEXT">abc</field>
                                    </shadow>
                                    <block type="variables_get"><field id="P|b0sa?k$1vcEdVj!+fn" name="VAR">n</field>
                                    </block>
                                </value>
                                <value name="val_Employee">
                                    <block type="lists_create_with"><mutation items="0"></mutation>
                                    </block>
                                </value>
                            </block>
                        </value>
                        <next>
                            <block type="variables_set" inline="true">
                                <field id="P|b0sa?k$1vcEdVj!+fn" name="VAR">n</field>
                                <value name="VALUE">
                                    <block type="api_DB_Departments_POST"><value name="val_department"><shadow type="TestBlocklyHtml_DB_Department"></shadow><block type="variables_get"><field id="nIdI=p;YaqO~NJ428@8h" name="VAR">var_Department</field>
                                            </block>
                                        </value>
                                    </block>
                                </value>
                                <next>
                                    <block type="text_print">
                                        <value name="TEXT">
                                            <shadow type="text"><field name="TEXT">abc</field>
                                            </shadow>
                                            <block type="api_DB_Departments_GET"></block>
                                        </value>
                                    </block>
                                </next>
                            </block>
                        </next>
                    </block>
                </next>
            </block>
        </next>
    </block>
</xml>`
    }
    ,
    {
        name: 'DB get department',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="$l{IZ#6T!0KWuO$YamR8">var_Int64</variable>
        <variable id="5$qv[vi$Yz%$3,\`/CML7">var_Department</variable>
    </variables>
    <block type="variables_set" y="20" x="20" inline="true">
        <field id="$l{IZ#6T!0KWuO$YamR8" name="VAR">var_Int64</field>
        <value name="VALUE">
            <block type="math_number">
                <field name="NUM">1</field>
            </block>
        </value>
        <next>
            <block type="variables_set">
                <field id="5$qv[vi$Yz%$3,\`/CML7" name="VAR">var_Department</field>
                <value name="VALUE">
                    <block type="converttojson">
                        <value name="ValueToConvert">
                            <block type="api_DB_Departments__id__GET">
                                <value name="val_id">
                                    <shadow type="System_Int64"></shadow>
                                    <block type="variables_get"><field id="$l{IZ#6T!0KWuO$YamR8" name="VAR">var_Int64</field>
                                    </block>
                                </value>
                            </block>
                        </value>
                    </block>
                </value>
                <next>
                    <block type="text_print">
                        <value name="TEXT">
                            <shadow type="text">
                                <field name="TEXT">abc</field>
                            </shadow>
                            <block type="converttostring">
                                <value name="ValueToConvert">
                                    <block type="variables_get"><field id="5$qv[vi$Yz%$3,\`/CML7" name="VAR">var_Department</field>
                                    </block>
                                </value>
                            </block>
                        </value>
                    </block>
                </next>
            </block>
        </next>
    </block>
</xml>`
    },
    {
        name: 'DB modify name department',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="$l{IZ#6T!0KWuO$YamR8">var_Int64</variable>
        <variable id="5$qv[vi$Yz%$3,\`/CML7">var_Department</variable>
        <variable id="Fy|}ia7w!]Uz},vn[LJc">message</variable>
        <variable id="0C5Rz_j*A1X!Eq24e[3h">newDepName</variable>
    </variables>
    <block type="variables_set" y="19" x="-252" inline="true">
        <field id="$l{IZ#6T!0KWuO$YamR8" name="VAR">var_Int64</field>
        <value name="VALUE">
            <block type="math_number">
                <field name="NUM">1</field>
            </block>
        </value>
        <next>
            <block type="variables_set">
                <field id="5$qv[vi$Yz%$3,\`/CML7" name="VAR">var_Department</field>
                <value name="VALUE">
                    <block type="converttojson">
                        <value name="ValueToConvert">
                            <block type="api_DB_Departments__id__GET">
                                <value name="val_id">
                                    <shadow type="System_Int64"></shadow>
                                    <block type="variables_get"><field id="$l{IZ#6T!0KWuO$YamR8" name="VAR">var_Int64</field>
                                    </block>
                                </value>
                            </block>
                        </value>
                    </block>
                </value>
                <next>
                    <block type="text_print">
                        <value name="TEXT">
                            <shadow type="text">
                                <field name="TEXT">abc</field>
                            </shadow>
                            <block type="converttostring">
                                <value name="ValueToConvert">
                                    <block type="variables_get"><field id="5$qv[vi$Yz%$3,\`/CML7" name="VAR">var_Department</field>
                                    </block>
                                </value>
                            </block>
                        </value>
                        <next>
                            <block type="variables_set">
                                <field id="Fy|}ia7w!]Uz},vn[LJc" name="VAR">message</field>
                                <value name="VALUE">
                                    <block type="text"><field name="TEXT">Please enter new name for Department ( old name :</field>
                                    </block>
                                </value>
                                <next>
                                    <block type="text_append"><field id="Fy|}ia7w!]Uz},vn[LJc" name="VAR">message</field><value name="TEXT"><shadow type="text"><field name="TEXT"></field>
                                            </shadow>
                                            <block type="getproperty"><field name="objectName">object</field><field name="prop">property</field><value name="ObjectToChange"><block type="variables_get"><field id="5$qv[vi$Yz%$3,\`/CML7" name="VAR">var_Department</field>
                                                    </block>
                                                </value>
                                                <value name="PropertyName">
                                                    <block type="text"><field name="TEXT">name</field>
                                                    </block>
                                                </value>
                                            </block>
                                        </value>
                                        <next>
                                            <block type="text_append">
                                                <field id="Fy|}ia7w!]Uz},vn[LJc" name="VAR">message</field>
                                                <value name="TEXT">
                                                    <shadow type="text"><field name="TEXT">):</field>
                                                    </shadow>
                                                </value>
                                                <next>
                                                    <block type="variables_set"><field id="0C5Rz_j*A1X!Eq24e[3h" name="VAR">newDepName</field><value name="VALUE"><block type="text_prompt_ext"><mutation type="TEXT"></mutation><field name="TYPE">TEXT</field><value name="TEXT"><shadow type="text"><field name="TEXT">abc</field>
                                                                    </shadow>
                                                                    <block type="variables_get"><field id="Fy|}ia7w!]Uz},vn[LJc" name="VAR">message</field>
                                                                    </block>
                                                                </value>
                                                            </block>
                                                        </value>
                                                        <next>
                                                            <block type="modifyproperty">
                                                                <field name="objectName">object</field>
                                                                <field name="prop">,property</field>
                                                                <field name="newValue">toValue</field>
                                                                <value name="ObjectToChange">
                                                                    <block type="variables_get"><field id="5$qv[vi$Yz%$3,\`/CML7" name="VAR">var_Department</field>
                                                                    </block>
                                                                </value>
                                                                <value name="PropertyName">
                                                                    <block type="text"><field name="TEXT">name</field>
                                                                    </block>
                                                                </value>
                                                                <value name="NewValue">
                                                                    <block type="variables_get"><field id="0C5Rz_j*A1X!Eq24e[3h" name="VAR">newDepName</field>
                                                                    </block>
                                                                </value>
                                                                <next>
                                                                    <block type="text_print"><value name="TEXT"><shadow type="text"><field name="TEXT">abc</field>
                                                                            </shadow>
                                                                            <block type="converttostring"><value name="ValueToConvert"><block type="variables_get"><field id="5$qv[vi$Yz%$3,\`/CML7" name="VAR">var_Department</field>
                                                                                    </block>
                                                                                </value>
                                                                            </block>
                                                                        </value>
                                                                        <next>
                                                                            <block type="text_print">
                                                                                <value name="TEXT">
                                                                                    <shadow type="text"><field name="TEXT">abc</field>
                                                                                    </shadow>
                                                                                    <block type="api_DB_Departments__id__PUT"><value name="val_id"><shadow type="System_Int64"></shadow><block type="variables_get"><field id="$l{IZ#6T!0KWuO$YamR8" name="VAR">var_Int64</field>
                                                                                            </block>
                                                                                        </value>
                                                                                        <value name="val_department">
                                                                                            <shadow type="TestBlocklyHtml_DB_Department"></shadow>
                                                                                            <block type="variables_get"><field id="5$qv[vi$Yz%$3,\`/CML7" name="VAR">var_Department</field>
                                                                                            </block>
                                                                                        </value>
                                                                                    </block>
                                                                                </value>
                                                                                <next>
                                                                                    <block type="variables_set">
                                                                                        <field id="5$qv[vi$Yz%$3,\`/CML7" name="VAR">var_Department</field>
                                                                                        <value name="VALUE">
                                                                                            <block type="converttojson"><value name="ValueToConvert"><block type="api_DB_Departments__id__GET"><value name="val_id"><shadow type="System_Int64"></shadow><block type="variables_get"><field id="$l{IZ#6T!0KWuO$YamR8" name="VAR">var_Int64</field>
                                                                                                            </block>
                                                                                                        </value>
                                                                                                    </block>
                                                                                                </value>
                                                                                            </block>
                                                                                        </value>
                                                                                        <next>
                                                                                            <block type="text_print">
                                                                                                <value name="TEXT">
                                                                                                    <shadow type="text">
                                                                                                        <field name="TEXT">abc</field>
                                                                                                    </shadow>
                                                                                                    <block type="getproperty">
                                                                                                        <field name="objectName">object</field>
                                                                                                        <field name="prop">property</field>
                                                                                                        <value name="ObjectToChange">
                                                                                                            <block type="variables_get"><field id="5$qv[vi$Yz%$3,\`/CML7" name="VAR">var_Department</field>
                                                                                                            </block>
                                                                                                        </value>
                                                                                                        <value name="PropertyName">
                                                                                                            <block type="text"><field name="TEXT">name</field>
                                                                                                            </block>
                                                                                                        </value>
                                                                                                    </block>
                                                                                                </value>
                                                                                            </block>
                                                                                        </next>
                                                                                    </block>
                                                                                </next>
                                                                            </block>
                                                                        </next>
                                                                    </block>
                                                                </next>
                                                            </block>
                                                        </next>
                                                    </block>
                                                </next>
                                            </block>
                                        </next>
                                    </block>
                                </next>
                            </block>
                        </next>
                    </block>
                </next>
            </block>
        </next>
    </block>
</xml>`
    },
    {
        name: 'DB Delete Department',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="P|b0sa?k$1vcEdVj!+fn">n</variable>
        <variable id="5;47gpsWUe91G}.~H]Om">var_Int64</variable>
        <variable id="nIdI=p;YaqO~NJ428@8h">var_Department</variable>
    </variables>
    <block type="text_print" y="-389" x="-394">
        <value name="TEXT">
            <shadow type="text">
                <field name="TEXT">abc</field>
            </shadow>
            <block type="text_length">
                <value name="VALUE">
                    <shadow type="text">
                        <field name="TEXT">abc</field>
                    </shadow>
                    <block type="converttojson">
                        <value name="ValueToConvert">
                            <block type="api_DB_Departments_GET"></block>
                        </value>
                    </block>
                </value>
            </block>
        </value>
        <next>
            <block type="variables_set" inline="true">
                <field id="P|b0sa?k$1vcEdVj!+fn" name="VAR">n</field>
                <value name="VALUE">
                    <block type="text_prompt_ext">
                        <mutation type="TEXT"></mutation>
                        <field name="TYPE">TEXT</field>
                        <value name="TEXT">
                            <shadow type="text">
                                <field name="TEXT">Please give name of the new Department</field>
                            </shadow>
                        </value>
                    </block>
                </value>
                <next>
                    <block type="variables_set">
                        <field id="5;47gpsWUe91G}.~H]Om" name="VAR">var_Int64</field>
                        <value name="VALUE">
                            <block type="math_number">
                                <field name="NUM">342</field>
                            </block>
                        </value>
                        <next>
                            <block type="variables_set">
                                <field id="nIdI=p;YaqO~NJ428@8h" name="VAR">var_Department</field>
                                <value name="VALUE">
                                    <block type="TestBlocklyHtml_DB_Department"><value name="val_Iddepartment"><block type="variables_get"><field id="5;47gpsWUe91G}.~H]Om" name="VAR">var_Int64</field>
                                            </block>
                                        </value>
                                        <value name="val_Name">
                                            <shadow type="text"><field name="TEXT">abc</field>
                                            </shadow>
                                            <block type="variables_get"><field id="P|b0sa?k$1vcEdVj!+fn" name="VAR">n</field>
                                            </block>
                                        </value>
                                        <value name="val_Employee">
                                            <block type="lists_create_with"><mutation items="0"></mutation>
                                            </block>
                                        </value>
                                    </block>
                                </value>
                                <next>
                                    <block type="variables_set" inline="true">
                                        <field id="P|b0sa?k$1vcEdVj!+fn" name="VAR">n</field>
                                        <value name="VALUE">
                                            <block type="api_DB_Departments_POST"><value name="val_department"><shadow type="TestBlocklyHtml_DB_Department"></shadow><block type="variables_get"><field id="nIdI=p;YaqO~NJ428@8h" name="VAR">var_Department</field>
                                                    </block>
                                                </value>
                                            </block>
                                        </value>
                                        <next>
                                            <block type="text_print">
                                                <value name="TEXT">
                                                    <shadow type="text"><field name="TEXT">abc</field>
                                                    </shadow>
                                                    <block type="text_length"><value name="VALUE"><shadow type="text"><field name="TEXT">abc</field>
                                                            </shadow>
                                                            <block type="converttojson"><value name="ValueToConvert"><block type="api_DB_Departments_GET"></block>
                                                                </value>
                                                            </block>
                                                        </value>
                                                    </block>
                                                </value>
                                                <next>
                                                    <block type="text_print">
                                                        <value name="TEXT">
                                                            <shadow type="text">
                                                                <field name="TEXT">abc</field>
                                                            </shadow>
                                                            <block type="api_DB_Departments__id__DELETE">
                                                                <value name="val_id"><shadow type="System_Int64"></shadow><block type="variables_get"><field id="5;47gpsWUe91G}.~H]Om" name="VAR">var_Int64</field>
                                                                    </block>
                                                                </value>
                                                            </block>
                                                        </value>
                                                        <next>
                                                            <block type="text_print">
                                                                <value name="TEXT">
                                                                    <shadow type="text"><field name="TEXT">abc</field>
                                                                    </shadow>
                                                                    <block type="text_length"><value name="VALUE"><shadow type="text"><field name="TEXT">abc</field>
                                                                            </shadow>
                                                                            <block type="converttojson"><value name="ValueToConvert"><block type="api_DB_Departments_GET"></block>
                                                                                </value>
                                                                            </block>
                                                                        </value>
                                                                    </block>
                                                                </value>
                                                            </block>
                                                        </next>
                                                    </block>
                                                </next>
                                            </block>
                                        </next>
                                    </block>
                                </next>
                            </block>
                        </next>
                    </block>
                </next>
            </block>
        </next>
    </block>
</xml>
`
    },
    {
        name: 'save new department',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <block type="text_print" y="-389" x="-404">
        <value name="TEXT">
            <shadow type="text">
                <field name="TEXT">abc</field>
            </shadow>
            <block type="api_DB_Departments_GET"></block>
        </value>
        <next>
            <block type="text_print">
                <value name="TEXT">
                    <shadow type="text">
                        <field name="TEXT">abc</field>
                    </shadow>
                    <block type="api_DB_Departments_POST">
                        <value name="val_department">
                            <shadow type="TestBlocklyHtml_DB_Department"></shadow>
                            <block type="TestBlocklyHtml_DB_Department">
                                <value name="val_Name">
                                    <shadow type="text"><field name="TEXT">asdasda</field>
                                    </shadow>
                                </value>
                                <value name="val_Employee">
                                    <shadow type="lists_create_with"><mutation items="0"></mutation>
                                    </shadow>
                                </value>
                            </block>
                        </value>
                    </block>
                </value>
                <next>
                    <block type="text_print">
                        <value name="TEXT">
                            <shadow type="text">
                                <field name="TEXT">abc</field>
                            </shadow>
                            <block type="api_DB_Departments_GET"></block>
                        </value>
                    </block>
                </next>
            </block>
        </next>
    </block>
</xml>`
    },
    {
        'name': 'play with enum',
        'data': `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="O\`.BZZ!oEpMmp,awb%m7">n</variable>
    </variables>
    <block type="variables_set" y="20" x="20" inline="true">
        <field id="O\`.BZZ!oEpMmp,awb%m7" name="VAR">n</field>
        <value name="VALUE">
            <block type="TestBlocklyHtml_Operation">
                <field name="val_Operation">3</field>
            </block>
        </value>
        <next>
            <block type="text_print">
                <value name="TEXT">
                    <shadow type="text">
                        <field name="TEXT">abc</field>
                    </shadow>
                    <block type="api_MathOperations_Operation__id___x__POST">
                        <value name="val_id">
                            <shadow type="TestBlocklyHtml_Operation">
                                <field name="val_Operation">0</field>
                            </shadow>
                            <block type="variables_get">
                                <field id="O\`.BZZ!oEpMmp,awb%m7" name="VAR">n</field>
                            </block>
                        </value>
                        <value name="val_x">
                            <shadow type="math_number">
                                <field name="NUM">10</field>
                            </shadow>
                        </value>
                        <value name="val_data">
                            <shadow type="TestBlocklyHtml_Math2Values"></shadow>
                            <block type="TestBlocklyHtml_Math2Values">
                                <value name="val_x">
                                    <shadow type="math_number"><field name="NUM">2</field>
                                    </shadow>
                                </value>
                                <value name="val_y">
                                    <shadow type="math_number"><field name="NUM">3</field>
                                    </shadow>
                                </value>
                            </block>
                        </value>
                    </block>
                </value>
            </block>
        </next>
    </block>
</xml>`
    },
    {
        'name': 'https://github.com/ignatandrei/NETCoreBlockly/issues/7',
        'data': `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="tN1o#/fr2(SEQn^Q#~j-">n</variable>
    </variables>
    <block type="variables_set" y="20" x="20" inline="true">
        <field id="tN1o#/fr2(SEQn^Q#~j-" name="VAR">n</field>
        <value name="VALUE">
            <block type="math_number">
                <field name="NUM">1</field>
            </block>
        </value>
        <next>
            <block type="text_print">
                <value name="TEXT">
                    <block type="api_MathOperations_ThrowError_POST"></block>
                </value>
                <next>
                    <block type="text_print">
                        <value name="TEXT">
                            <block type="variables_get">
                                <field id="tN1o#/fr2(SEQn^Q#~j-" name="VAR">n</field>
                            </block>
                        </value>
                    </block>
                </next>
            </block>
        </next>
    </block>
</xml>`
    },
    {
        'name': 'simple query string',
        'data':`<xml xmlns="https://developers.google.com/blockly/xml">
    <block type="text_print" y="22" x="39">
        <value name="TEXT">
            <block type="api_RestWithArgs_PostWithArgs_POST">
                <value name="val_value">
                    <shadow type="text">
                        <field name="TEXT">Bring me back</field>
                    </shadow>
                </value>
            </block>
        </value>
    </block>
</xml>`
    }
]
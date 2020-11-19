//if you want to copy those blocks, make sure you replace \` with `
var testBlocks =
    [
    {
        name: 'save image',
        data: `<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="^HqtU]3:/R^Xs!?,#:]m">n</variable>
        <variable id="f~YJqnSTlX^GoI/nN*h~">nameFile</variable>
        <variable id=",QS2XTKZ]7gJZ_KB#gQ_">imgContent</variable>
    </variables>
    <block type="variables_set" y="20" x="20" inline="true">
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
    <block type="variables_set" y="20" x="20" inline="true">
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
    <block id="set_n_initial" type="variables_set" y="20" x="20" inline="true">
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
    <block type="variables_set" y="20" x="20" inline="true">
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
    <block type="variables_set" y="20" x="20" inline="true">
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
        name: 'error in  javascript generated',
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
    <block type="variables_set" y="20" x="20" inline="true">
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
    <block type="text_print" y="20" x="20">
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
    <block type="text_print" y="20" x="20">
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
        'name': 'error',
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
    <block type="text_print" y="22" x="20">
        <value name="TEXT">
            <block type="api_RestWithArgs_PostWithArgs_value_POST">
                <value name="val_value">
                    <shadow type="text">
                        <field name="TEXT">Bring me back</field>
                    </shadow>
                </value>
            </block>
        </value>
    </block>
</xml>`
    },
    {
        name: 'chuck norris random joke',
        data:`<xml xmlns="https://developers.google.com/blockly/xml">
    <variables>
        <variable id="sDL./h^zT]uA,gn%uSp^">urlName</variable>
        <variable id="d#~hn(B|Lt|O=M~N]n]Y">answer</variable>
    </variables>
    <block type="variables_set" y="20" x="20">
        <field id="sDL./h^zT]uA,gn%uSp^" name="VAR">urlName</field>
        <value name="VALUE">
            <block type="text">
                <field name="TEXT">https://api.chucknorris.io/jokes/random</field>
            </block>
        </value>
        <next>
            <block type="variables_set">
                <field id="d#~hn(B|Lt|O=M~N]n]Y" name="VAR">answer</field>
                <value name="VALUE">
                    <block type="httprequest">
                        <field name="TypeOutput">JSON</field>
                        <field name="TypeRequest">GET</field>
                        <value name="TheUrl">
                            <shadow type="text">
                                <field name="TEXT">https://api.chucknorris.io/jokes/random</field>
                            </shadow>
                            <block type="variables_get">
                                <field id="sDL./h^zT]uA,gn%uSp^" name="VAR">urlName</field>
                            </block>
                        </value>
                    </block>
                </value>
                <next>
                    <block type="text_print">
                        <value name="TEXT">
                            <block type="variables_get">
                                <field id="d#~hn(B|Lt|O=M~N]n]Y" name="VAR">answer</field>
                            </block>
                        </value>
                        <next>
                            <block type="text_print">
                                <value name="TEXT">
                                    <block type="getproperty"><field name="objectName">object</field><field name="prop">property</field><value name="ObjectToChange"><block type="variables_get"><field id="d#~hn(B|Lt|O=M~N]n]Y" name="VAR">answer</field>
                                            </block>
                                        </value>
                                        <value name="PropertyName">
                                            <block type="text"><field name="TEXT">value</field>
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
        name: 'JWT Bearer',
        data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <block type="headersbeforehttp" y="20" x="20">
    <value name="HttpDomain">
      <shadow type="text">
        <field name="TEXT">(localSite)</field>
      </shadow>
    </value>
    <value name="HeaderName">
      <shadow type="text">
        <field name="TEXT">Authorization</field>
      </shadow>
    </value>
    <value name="HeaderValue">
      <shadow type="text">
        <field name="TEXT"></field>
      </shadow>
      <block type="text_join">
        <mutation items="2"></mutation>
        <value name="ADD0">
          <block type="text">
            <field name="TEXT">CustomBearer </field>
          </block>
        </value>
        <value name="ADD1">
          <block type="api_Registration_POST">
            <value name="val_secretCode">
              <shadow type="text">
                <field name="TEXT">blockly</field>
              </shadow>
            </value>
          </block>
        </value>
      </block>
    </value>
    <next>
      <block type="text_print">
        <value name="TEXT">
          <block type="api_RestrictedAccess_CustomJWT_GET"></block>
        </value>
      </block>
    </next>
  </block>
</xml>`
    },
    {
        name: 'NASA image',
        data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <variables>
    <variable id="sDL./h^zT]uA,gn%uSp^">urlName</variable>
    <variable id="d#~hn(B|Lt|O=M~N]n]Y">answer</variable>
  </variables>
  <block type="variables_set" y="20" x="20">
    <field id="sDL./h^zT]uA,gn%uSp^" name="VAR">urlName</field>
    <value name="VALUE">
      <block type="text">
        <field name="TEXT">https://api.nasa.gov/planetary/apod?api_key=VHWR2tDJz47FuQZQccUS4MpyQyplcG9C0VpfpNQo</field>
      </block>
    </value>
    <next>
      <block type="variables_set">
        <field id="d#~hn(B|Lt|O=M~N]n]Y" name="VAR">answer</field>
        <value name="VALUE">
          <block type="httprequest">
            <field name="TypeOutput">JSON</field>
            <field name="TypeRequest">GET</field>
            <value name="TheUrl">
              <shadow type="text">
                <field name="TEXT">https://api.chucknorris.io/jokes/random</field>
              </shadow>
              <block type="variables_get">
                <field id="sDL./h^zT]uA,gn%uSp^" name="VAR">urlName</field>
              </block>
            </value>
          </block>
        </value>
        <next>
          <block type="text_print">
            <value name="TEXT">
              <block type="variables_get">
                <field id="d#~hn(B|Lt|O=M~N]n]Y" name="VAR">answer</field>
              </block>
            </value>
            <next>
              <block type="text_print">
                <value name="TEXT">
                  <block type="getproperty">
                    <field name="objectName">object</field>
                    <field name="prop">property</field>
                    <value name="ObjectToChange">
                      <block type="variables_get">
                        <field id="d#~hn(B|Lt|O=M~N]n]Y" name="VAR">answer</field>
                      </block>
                    </value>
                    <value name="PropertyName">
                      <block type="text">
                        <field name="TEXT">title</field>
                      </block>
                    </value>
                  </block>
                </value>
                <next>
                  <block type="text_print">
                    <value name="TEXT">
                      <block type="getproperty">
                        <field name="objectName">object</field>
                        <field name="prop">property</field>
                        <value name="ObjectToChange">
                          <block type="variables_get">
                            <field id="d#~hn(B|Lt|O=M~N]n]Y" name="VAR">answer</field>
                          </block>
                        </value>
                        <value name="PropertyName">
                          <block type="text">
                            <field name="TEXT">explanation</field>
                          </block>
                        </value>
                      </block>
                    </value>
                    <next>
                      <block type="window_open">
                        <value name="TEXT">
                          <block type="getproperty">
                            <field name="objectName">object</field>
                            <field name="prop">property</field>
                            <value name="ObjectToChange">
                              <block type="variables_get">
                                <field id="d#~hn(B|Lt|O=M~N]n]Y" name="VAR">answer</field>
                              </block>
                            </value>
                            <value name="PropertyName">
                              <block type="text">
                                <field name="TEXT">url</field>
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
        name: 'date',
        data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <block type="text_print" y="20" x="20">
    <value name="TEXT">
      <block type="displayCurrentDate">
        <field name="dateFormat">iso</field>
      </block>
    </value>
  </block>
</xml>`
    },
    {
        name: 'swagger create pet (what if we put 0 as petid?)',
        data:`<xml xmlns=\"https://developers.google.com/blockly/xml\">
    <variables>
        <variable id=\"hO\`?kR*XbVn|uJq:?jJ_\">n</variable>  
    </variables>  
    <block type=\"variables_set\" inline=\"true\" x=\"20\" y=\"20\">
        <field name=\"VAR\" id=\"hO\`?kR*XbVn|uJq:?jJ_\">n</field>    
        <value name=\"VALUE\">
            <block type=\"petstore_swagger_io_v2__pet_post\">
                <value name=\"val_Pet\">
                    <shadow type=\"petstore_swagger_iov2_Pet\"></shadow>          
                    <block type=\"petstore_swagger_iov2_Pet\">
                        <value name=\"val_category\">
                            <block type=\"petstore_swagger_iov2_Category\">
                                <value name=\"val_id\">
                                    <shadow type=\"math_number\"><field name=\"NUM\">0</field>                  
                                    </shadow>                
                                </value>                
                                <value name=\"val_name\">
                                    <shadow type=\"text\"><field name=\"TEXT\">test</field>                  
                                    </shadow>                
                                </value>              
                            </block>            
                        </value>            
                        <value name=\"val_id\">
                            <shadow type=\"math_number\">
                                <field name=\"NUM\">0</field>              
                            </shadow>              
                            <block type=\"math_number\">
                                <field name=\"NUM\">1</field>              
                            </block>            
                        </value>            
                        <value name=\"val_name\">
                            <shadow type=\"text\">
                                <field name=\"TEXT\">MyPet</field>              
                            </shadow>            
                        </value>            
                        <value name=\"val_photoUrls\">
                            <shadow type=\"lists_create_with\">
                                <mutation items=\"0\"></mutation>              
                            </shadow>            
                        </value>            
                        <value name=\"val_status\">
                            <shadow type=\"text\">
                                <field name=\"TEXT\">ss</field>              
                            </shadow>            
                        </value>            
                        <value name=\"val_tags\">
                            <shadow type=\"lists_create_with\">
                                <mutation items=\"0\"></mutation>              
                            </shadow>            
                        </value>          
                    </block>        
                </value>      
            </block>    
        </value>    
        <next>
            <block type=\"variables_set\">
                <field name=\"VAR\" id=\"hO\`?kR*XbVn|uJq:?jJ_\">n</field>        
                <value name=\"VALUE\">
                    <block type=\"getproperty\">
                        <field name=\"objectName\">object</field>            
                        <field name=\"prop\">property</field>            
                        <value name=\"ObjectToChange\">
                            <block type=\"converttojson\">
                                <value name=\"ValueToConvert\">
                                    <block type=\"variables_get\"><field name=\"VAR\" id=\"hO\`?kR*XbVn|uJq:?jJ_\">n</field>                  
                                    </block>                
                                </value>              
                            </block>            
                        </value>            
                        <value name=\"PropertyName\">
                            <block type=\"text\">
                                <field name=\"TEXT\">id</field>              
                            </block>            
                        </value>          
                    </block>        
                </value>        
                <next>
                    <block type=\"text_print\">
                        <value name=\"TEXT\">
                            <block type=\"variables_get\">
                                <field name=\"VAR\" id=\"hO\`?kR*XbVn|uJq:?jJ_\">n</field>              
                            </block>            
                        </value>            
                        <next>
                            <block type=\"text_print\">
                                <value name=\"TEXT\">
                                    <block type=\"petstore_swagger_io_v2__pet__petId__get\"><value name=\"val_petId\"><shadow type=\"math_number\"><field name=\"NUM\">0</field>                      
                                            </shadow>                      
                                            <block type=\"variables_get\"><field name=\"VAR\" id=\"hO\`?kR*XbVn|uJq:?jJ_\">n</field>                      
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
        name: 'odata airport',
        data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <block type="text_print" y="20" x="20">
    <value name="TEXT">
      <block type="services_odata_org_TripPinRESTierService__Airports_____IcaoCode______GET">
        <value name="val_IcaoCode">
          <block type="text">
            <field name="TEXT">KSFO</field>
          </block>
        </value>
      </block>
    </value>
  </block>
</xml>`
    },
    {
        name: 'odata top skip select ',
        data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <block type="text_print" y="20" x="20">
    <value name="TEXT">
      <block type="services_odata_org_TripPinRESTierService__Airports__count__top__skip__select_GET">
        <value name="val_$count">
          <shadow type="logic_boolean">
            <field name="BOOL">FALSE</field>
          </shadow>
        </value>
        <value name="val_$top">
          <shadow type="math_number">
            <field name="NUM">2</field>
          </shadow>
        </value>
        <value name="val_$skip">
          <shadow type="math_number">
            <field name="NUM">0</field>
          </shadow>
        </value>
        <value name="val_$select">
          <shadow type="text">
            <field name="TEXT">IataCode,Location</field>
          </shadow>
        </value>
      </block>
    </value>
  </block>
</xml>`
    },
    {
        name: 'odata v3',
        data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <block type="headersbeforehttp" y="20" x="20">
    <value name="HttpDomain">
      <shadow type="text">
        <field name="TEXT">services.odata.org</field>
      </shadow>
    </value>
    <value name="HeaderName">
      <shadow type="text">
        <field name="TEXT">Accept</field>
      </shadow>
    </value>
    <value name="HeaderValue">
      <shadow type="text_join">
        <mutation items="2"></mutation>
      </shadow>
      <block type="text">
        <field name="TEXT">application/json</field>
      </block>
    </value>
    <next>
      <block type="text_print">
        <value name="TEXT">
          <block type="services_odata_org_V3_OData_OData_svc__Products__inlinecount__top__skip__select_GET">
            <value name="val_$inlinecount">
              <shadow type="text">
                <field name="TEXT">allpages</field>
              </shadow>
            </value>
            <value name="val_$top">
              <shadow type="math_number">
                <field name="NUM">3</field>
              </shadow>
            </value>
            <value name="val_$skip">
              <shadow type="math_number">
                <field name="NUM">0</field>
              </shadow>
            </value>
            <value name="val_$select">
              <shadow type="text">
                <field name="TEXT">ID,Name,Price</field>
              </shadow>
            </value>
          </block>
        </value>
      </block>
    </next>
  </block>
</xml>`
    },
    {
        name: 'ODATA local DB',
        data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <variables>
    <variable id="hO\`?kR*XbVn|uJq:?jJ_">n</variable>
    <variable id="J=uTKf528=Ou5g1ROhh-">var_OdataToEntity_EfCore_DynamicDataContext_Types_DynamicType1</variable>
  </variables>
  <block type="variables_set" inline="true" x="20" y="20">
    <field name="VAR" id="hO\`?kR*XbVn|uJq:?jJ_">n</field>
    <value name="VALUE">
      <block type="math_number">
        <field name="NUM">21</field>
      </block>
    </value>
    <next>
      <block type="variables_set">
        <field name="VAR" id="J=uTKf528=Ou5g1ROhh-">var_OdataToEntity_EfCore_DynamicDataContext_Types_DynamicType1</field>
        <value name="VALUE">
          <block type="OdataToEntity.EfCore.DynamicDataContext.Types.DynamicType1">
            <value name="val_idClassRoom">
              <shadow type="math_number">
                <field name="NUM">0</field>
              </shadow>
              <block type="variables_get">
                <field name="VAR" id="hO\`?kR*XbVn|uJq:?jJ_">n</field>
              </block>
            </value>
            <value name="val_Name">
              <shadow type="text">
                <field name="TEXT">first</field>
              </shadow>
            </value>
            <value name="val_Students">
              <shadow type="lists_create_with">
                <mutation items="0"></mutation>
              </shadow>
            </value>
          </block>
        </value>
        <next>
          <block type="text_print">
            <value name="TEXT">
              <block type="_odataDB_ClassRoom_GET"></block>
            </value>
            <next>
              <block type="text_print">
                <value name="TEXT">
                  <block type="_odataDB_ClassRoom_POST">
                    <value name="val_ClassRoom">
                      <shadow type="OdataToEntity.EfCore.DynamicDataContext.Types.DynamicType1"></shadow>
                      <block type="variables_get">
                        <field name="VAR" id="J=uTKf528=Ou5g1ROhh-">var_OdataToEntity_EfCore_DynamicDataContext_Types_DynamicType1</field>
                      </block>
                    </value>
                  </block>
                </value>
                <next>
                  <block type="text_print">
                    <value name="TEXT">
                      <block type="_odataDB_ClassRoom__idClassRoom___GET">
                        <value name="val_idClassRoom">
                          <shadow type="math_number">
                            <field name="NUM">0</field>
                          </shadow>
                          <block type="variables_get">
                            <field name="VAR" id="hO\`?kR*XbVn|uJq:?jJ_">n</field>
                          </block>
                        </value>
                      </block>
                    </value>
                    <next>
                      <block type="text_print">
                        <value name="TEXT">
                          <block type="_odataDB_ClassRoom__idClassRoom___PATCH">
                            <value name="val_idClassRoom">
                              <shadow type="math_number">
                                <field name="NUM">0</field>
                              </shadow>
                              <block type="variables_get">
                                <field name="VAR" id="hO\`?kR*XbVn|uJq:?jJ_">n</field>
                              </block>
                            </value>
                            <value name="val_ClassRoom">
                              <shadow type="OdataToEntity.EfCore.DynamicDataContext.Types.DynamicType1"></shadow>
                              <block type="OdataToEntity.EfCore.DynamicDataContext.Types.DynamicType1">
                                <value name="val_idClassRoom">
                                  <shadow type="math_number">
                                    <field name="NUM">0</field>
                                  </shadow>
                                  <block type="variables_get">
                                    <field name="VAR" id="hO\`?kR*XbVn|uJq:?jJ_">n</field>
                                  </block>
                                </value>
                                <value name="val_Name">
                                  <shadow type="text">
                                    <field name="TEXT">second</field>
                                  </shadow>
                                </value>
                                <value name="val_Students">
                                  <shadow type="lists_create_with">
                                    <mutation items="0"></mutation>
                                  </shadow>
                                </value>
                              </block>
                            </value>
                          </block>
                        </value>
                        <next>
                          <block type="text_print">
                            <value name="TEXT">
                              <block type="_odataDB_ClassRoom__idClassRoom___GET">
                                <value name="val_idClassRoom">
                                  <shadow type="math_number">
                                    <field name="NUM">0</field>
                                  </shadow>
                                  <block type="variables_get">
                                    <field name="VAR" id="hO\`?kR*XbVn|uJq:?jJ_">n</field>
                                  </block>
                                </value>
                              </block>
                            </value>
                            <next>
                              <block type="text_print">
                                <value name="TEXT">
                                  <block type="_odataDB_ClassRoom__idClassRoom___DELETE">
                                    <value name="val_idClassRoom">
                                      <shadow type="math_number">
                                        <field name="NUM">0</field>
                                      </shadow>
                                      <block type="variables_get">
                                        <field name="VAR" id="hO\`?kR*XbVn|uJq:?jJ_">n</field>
                                      </block>
                                    </value>
                                  </block>
                                </value>
                                <next>
                                  <block type="text_print">
                                    <value name="TEXT">
                                      <block type="_odataDB_ClassRoom_GET"></block>
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
</xml>`
    },
    {
        name: 'first version auth0',
        data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <variables>
    <variable id="RRZ-(HL..n:DbSi7KPbv">token</variable>
  </variables>
  <block type="variables_set" x="20" y="20">
    <field name="VAR" id="RRZ-(HL..n:DbSi7KPbv">token</field>
    <value name="VALUE">
      <block type="httprequest">
        <field name="TypeOutput">JSON</field>
        <field name="TypeRequest">POST</field>
        <value name="TheUrl">
          <shadow type="text">
            <field name="TEXT">https://ignatandrei.eu.auth0.com/oauth/token</field>
          </shadow>
        </value>
        <value name="Data">
          <block type="auth0webapidata">
            <value name="client_id">
              <shadow type="text">
                <field name="TEXT">dvshpeMH6Jx9v3JY2NUrnhGqlCclFf7e</field>
              </shadow>
            </value>
            <value name="client_secret">
              <shadow type="text">
                <field name="TEXT">7Lt_K_YxV-_NBx4zHpyedZZSf728ZvtsfNjrjR_-6Qu_b05J5qBSGmVhEO0QaYUm</field>
              </shadow>
            </value>
            <value name="audience">
              <shadow type="text">
                <field name="TEXT">mytest</field>
              </shadow>
            </value>
            <value name="grant_type">
              <shadow type="text">
                <field name="TEXT">client_credentials</field>
              </shadow>
            </value>
          </block>
        </value>
      </block>
    </value>
    <next>
      <block type="variables_set">
        <field name="VAR" id="RRZ-(HL..n:DbSi7KPbv">token</field>
        <value name="VALUE">
          <block type="getproperty">
            <field name="objectName">object</field>
            <field name="prop">property</field>
            <value name="ObjectToChange">
              <block type="variables_get">
                <field name="VAR" id="RRZ-(HL..n:DbSi7KPbv">token</field>
              </block>
            </value>
            <value name="PropertyName">
              <block type="text">
                <field name="TEXT">access_token</field>
              </block>
            </value>
          </block>
        </value>
        <next>
          <block type="text_print">
            <value name="TEXT">
              <block type="variables_get">
                <field name="VAR" id="RRZ-(HL..n:DbSi7KPbv">token</field>
              </block>
            </value>
            <next>
              <block type="headersbeforehttp">
                <value name="HttpDomain">
                  <shadow type="text">
                    <field name="TEXT">(localSite)</field>
                  </shadow>
                </value>
                <value name="HeaderName">
                  <shadow type="text">
                    <field name="TEXT">Authorization</field>
                  </shadow>
                </value>
                <value name="HeaderValue">
                  <shadow type="text_join">
                    <mutation items="2"></mutation>
                  </shadow>
                  <block type="text_join">
                    <mutation items="2"></mutation>
                    <value name="ADD0">
                      <block type="text">
                        <field name="TEXT">Bearer </field>
                      </block>
                    </value>
                    <value name="ADD1">
                      <block type="variables_get">
                        <field name="VAR" id="RRZ-(HL..n:DbSi7KPbv">token</field>
                      </block>
                    </value>
                  </block>
                </value>
                <next>
                  <block type="text_print">
                    <value name="TEXT">
                      <block type="api_RestrictedAccess_Auth0Secret_GET"></block>
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
        name: 'IDictionary C#',
        data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <block type="text_print" x="20" y="20">
    <value name="TEXT">
      <block type="api_VariousTests_ActionWithDictionary_POST">
        <value name="val_id">
          <shadow type="lists_create_with">
            <mutation items="3"></mutation>
          </shadow>
          <block type="object_create">
            <mutation xmlns="http://www.w3.org/1999/xhtml" num_fields="2">
              <field name="asdas"></field>
              <field name="asdasd"></field>
            </mutation>
            <field name="field1">item1</field>
            <field name="field2">item2</field>
            <value name="field_input1">
              <block type="text">
                <field name="TEXT">2</field>
              </block>
            </value>
            <value name="field_input2">
              <block type="text">
                <field name="TEXT">3</field>
              </block>
            </value>
          </block>
        </value>
      </block>
    </value>
  </block>
</xml>`
    },
    {
        name: 'GraphQL Department',
        data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <block type="text_print" x="20" y="20">
    <value name="TEXT">
      <block type="_graphql_query__departmentQuery_iddepartment name___GET"></block>
    </value>
    <next>
      <block type="text_print">
        <value name="TEXT">
          <block type="_graphql_query__getOneDepartment_id__id___iddepartment name___id_GET">
            <value name="val_id">
              <shadow type="math_number">
                <field name="NUM">1</field>
              </shadow>
            </value>
          </block>
        </value>
      </block>
    </next>
  </block>
</xml>`
    },
    {
        name: 'graphql 2 arg string',
        data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <block type="text_print" x="20" y="20">
    <value name="TEXT">
      <block type="_graphql_query__getEmployeeAfterName_employeeName___employeeName__,departmentName___departmentName____idemployee name___employeeName_departmentName_GET">
        <value name="val_employeeName">
          <shadow type="text">
            <field name="TEXT">erson</field>
          </shadow>
        </value>
        <value name="val_departmentName">
          <shadow type="text">
            <field name="TEXT">IT</field>
          </shadow>
        </value>
      </block>
    </value>
  </block>
</xml>`
    },
    {
        name: 'test grid',
        data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <block type="text_print" x="20" y="20">
    <value name="TEXT">
      <block type="api_VariousTests_ReturnArrayStringForGrid_GET"></block>
    </value>
    <next>
      <block type="text_print">
        <value name="TEXT">
          <block type="WeatherForecast_GET"></block>
        </value>
      </block>
    </next>
  </block>
</xml>`
    },
    {
        name: 'filter list',
        data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <variables>
    <variable id="cn8tD}b,qY^62JyI+IFE">list</variable>
  </variables>
  <block type="variables_set" inline="true" x="20" y="20">
    <field name="VAR" id="cn8tD}b,qY^62JyI+IFE">list</field>
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
            <field name="VAR" id="cn8tD}b,qY^62JyI+IFE">list</field>
          </block>
        </value>
        <next>
          <block type="variables_set" inline="true">
            <field name="VAR" id="cn8tD}b,qY^62JyI+IFE">list</field>
            <value name="VALUE">
              <block type="converttojson">
                <value name="ValueToConvert">
                  <block type="variables_get">
                    <field name="VAR" id="cn8tD}b,qY^62JyI+IFE">list</field>
                  </block>
                </value>
              </block>
            </value>
            <next>
              <block type="variables_set" inline="true">
                <field name="VAR" id="cn8tD}b,qY^62JyI+IFE">list</field>
                <value name="VALUE">
                  <block type="filterList">
                    <value name="LIST">
                      <block type="variables_get">
                        <field name="VAR" id="cn8tD}b,qY^62JyI+IFE">list</field>
                      </block>
                    </value>
                    <value name="Logic">
                      <shadow type="text">
                        <field name="TEXT">item.summary == "Warm"</field>
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
                          <block type="variables_get">
                            <field name="VAR" id="cn8tD}b,qY^62JyI+IFE">list</field>
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
</xml>
`
        },
        {
            name: 'test null passing',
            data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <variables>
    <variable id="hO\`?kR*XbVn|uJq:?jJ_">n</variable>
  </variables>
  <block type="variables_set" inline="true" x="20" y="20">
    <field name="VAR" id="hO\`?kR*XbVn|uJq:?jJ_">n</field>
    <value name="VALUE">
      <block type="text">
        <field name="TEXT"></field>
      </block>
    </value>
    <next>
      <block type="text_print">
        <value name="TEXT">
          <block type="api_VariousTests_TestNullPassing__id__GET">
            <value name="val_id">
              <shadow type="math_number">
                <field name="NUM">0</field>
              </shadow>
              <block type="variables_get">
                <field name="VAR" id="hO\`?kR*XbVn|uJq:?jJ_">n</field>
              </block>
            </value>
          </block>
        </value>
        <next>
          <block type="text_print">
            <value name="TEXT">
              <block type="api_VariousTests_TestNullPassing__id__GET">
                <value name="val_id">
                  <shadow type="math_number">
                    <field name="NUM">0</field>
                  </shadow>
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
            name: 'testing wait',
            data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <block type="text_print" x="20" y="20">
    <value name="TEXT">
      <block type="displayCurrentDate">
        <field name="dateFormat">iso</field>
      </block>
    </value>
    <next>
      <block type="wait">
        <value name="VALUE">
      <shadow type="math_number">
        <field name="NUM">2</field>
      </shadow>
    </value>
        <next>
          <block type="text_print">
            <value name="TEXT">
              <block type="displayCurrentDate">
                <field name="dateFormat">iso</field>
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
            name: 'testing dates',
            data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <block type="text_print" x="20" y="20">
    <value name="TEXT">
      <shadow type="text">
        <field name="TEXT">abc</field>
      </shadow>
      <block type="DateFromText">
        <value name="VALUE">
          <shadow type="text">
            <field name="TEXT">1970-04-16</field>
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
          <block type="DateFromText">
            <value name="VALUE">
              <shadow type="text">
                <field name="TEXT">1970-04-16T02:00:00</field>
              </shadow>
            </value>
          </block>
        </value>
      </block>
    </next>
  </block>
</xml>`
        },
        {
            name: 'complicated wait',
            data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <variables>
    <variable id="r%BRT7Cx]L1ow]Cgt#(.">DateToDiff</variable>
    <variable id="bC%RDoP/K2A86d|6H}Bl">x</variable>
  </variables>
  <block type="procedures_defreturn" x="20" y="20">
    <mutation>
      <arg name="DateToDiff" varid="r%BRT7Cx]L1ow]Cgt#(."></arg>
    </mutation>
    <field name="NAME">SecondsDiffToNow</field>
    <comment pinned="false" h="80" w="160">SecondsDiff</comment>
    <statement name="STACK">
      <block type="variables_set">
        <field name="VAR" id="bC%RDoP/K2A86d|6H}Bl">x</field>
        <value name="VALUE">
          <block type="math_arithmetic">
            <field name="OP">MINUS</field>
            <value name="A">
              <shadow type="math_number">
                <field name="NUM">1</field>
              </shadow>
              <block type="variables_get">
                <field name="VAR" id="r%BRT7Cx]L1ow]Cgt#(.">DateToDiff</field>
              </block>
            </value>
            <value name="B">
              <shadow type="math_number">
                <field name="NUM">1</field>
              </shadow>
              <block type="displayCurrentDate">
                <field name="dateFormat">unix</field>
              </block>
            </value>
          </block>
        </value>
        <next>
          <block type="variables_set">
            <field name="VAR" id="bC%RDoP/K2A86d|6H}Bl">x</field>
            <value name="VALUE">
              <block type="math_arithmetic">
                <field name="OP">DIVIDE</field>
                <value name="A">
                  <shadow type="math_number">
                    <field name="NUM">1</field>
                  </shadow>
                  <block type="variables_get">
                    <field name="VAR" id="bC%RDoP/K2A86d|6H}Bl">x</field>
                  </block>
                </value>
                <value name="B">
                  <shadow type="math_number">
                    <field name="NUM">1000</field>
                  </shadow>
                </value>
              </block>
            </value>
          </block>
        </next>
      </block>
    </statement>
    <value name="RETURN">
      <block type="variables_get">
        <field name="VAR" id="bC%RDoP/K2A86d|6H}Bl">x</field>
      </block>
    </value>
  </block>
  <block type="text_print" x="-49" y="78">
    <value name="TEXT">
      <shadow type="text">
        <field name="TEXT">abc</field>
      </shadow>
      <block type="displayCurrentDate">
        <field name="dateFormat">iso</field>
      </block>
    </value>
    <next>
      <block type="wait">
        <value name="VALUE">
          <shadow type="math_number">
            <field name="NUM">10</field>
          </shadow>
          <block type="procedures_callreturn">
            <mutation name="SecondsDiffToNow">
              <arg name="DateToDiff"></arg>
            </mutation>
            <value name="ARG0">
              <block type="DateFromText">
                <value name="VALUE">
                  <shadow type="text">
                    <field name="TEXT">wait2Seconds</field>
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
              <block type="displayCurrentDate">
                <field name="dateFormat">iso</field>
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
            name: 'simple wait date',
            data: `<xml xmlns="https://developers.google.com/blockly/xml">
  <block type="text_print" x="20" y="20">
    <value name="TEXT">
      <block type="displayCurrentDate">
        <field name="dateFormat">iso</field>
      </block>
    </value>
    <next>
      <block type="wait_until">
        <value name="VALUE">
          <block type="DateFromText">
            <value name="VALUE">
              <shadow type="text">
                <field name="TEXT">wait2Seconds</field>
              </shadow>
            </value>
          </block>
        </value>
        <next>
          <block type="text_print">
            <value name="TEXT">
              <block type="displayCurrentDate">
                <field name="dateFormat">iso</field>
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
            name: 'test get property',
            data: `<xml xmlns="https://developers.google.com/blockly/xml">
  <variables>
    <variable id="hO\`?kR*XbVn|uJq:?jJ_">n</variable>
  </variables>
  <block type="variables_set" x="20" y="20">
    <field name="VAR" id="hO\`?kR*XbVn|uJq:?jJ_">n</field>
    <value name="VALUE">
      <block type="getproperty">
        <field name="objectName">object</field>
        <field name="prop">property</field>
        <value name="ObjectToChange">
          <block type="WeatherForecast_GET"></block>
        </value>
        <value name="PropertyName">
          <shadow type="text">
            <field name="TEXT">length</field>
          </shadow>
        </value>
      </block>
    </value>
    <next>
      <block type="text_print">
        <value name="TEXT">
          <block type="variables_get">
            <field name="VAR" id="hO\`?kR*XbVn|uJq:?jJ_">n</field>
          </block>
        </value>
        <next>
          <block type="variables_set">
            <field name="VAR" id="hO\`?kR*XbVn|uJq:?jJ_">n</field>
            <value name="VALUE">
              <block type="getproperty">
                <field name="objectName">object</field>
                <field name="prop">property</field>
                <value name="ObjectToChange">
                  <block type="converttojson">
                    <value name="ValueToConvert">
                      <block type="WeatherForecast_GET"></block>
                    </value>
                  </block>
                </value>
                <value name="PropertyName">
                  <shadow type="text">
                    <field name="TEXT">length</field>
                  </shadow>
                </value>
              </block>
            </value>
            <next>
              <block type="text_print">
                <value name="TEXT">
                  <block type="variables_get">
                    <field name="VAR" id="hO\`?kR*XbVn|uJq:?jJ_">n</field>
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
            name: 'map ',
            data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <variables>
    <variable id="cn8tD}b,qY^62JyI+IFE">list</variable>
  </variables>
  <block type="variables_set" inline="true" x="20" y="20">
    <field name="VAR" id="cn8tD}b,qY^62JyI+IFE">list</field>
    <value name="VALUE">
      <block type="WeatherForecast_GET"></block>
    </value>
    <next>
      <block type="variables_set" inline="true">
        <field name="VAR" id="cn8tD}b,qY^62JyI+IFE">list</field>
        <value name="VALUE">
          <block type="mapList">
            <value name="LIST">
              <block type="variables_get">
                <field name="VAR" id="cn8tD}b,qY^62JyI+IFE">list</field>
              </block>
            </value>
            <value name="Logic">
              <shadow type="text">
                <field name="TEXT">item.summary </field>
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
                  <block type="variables_get">
                    <field name="VAR" id="cn8tD}b,qY^62JyI+IFE">list</field>
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
            name: 'comments',
            data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <block type="comment" x="20" y="30">
    <field name="NAME"></field>
    <value name="TEXT">
      <block type="WeatherForecast_GET"></block>
    </value>
    <next>
      <block type="comment">
        <field name="NAME"></field>
        <value name="TEXT">
          <shadow type="text">
            <field name="TEXT">abc</field>
          </shadow>
        </value>
      </block>
    </next>
  </block>
</xml>`
        },
        {
            name: 'ZArduino',
            data:`<xml xmlns='https://developers.google.com/blockly/xml'>
  <variables>
    <variable id='hO\`?kR*XbVn|uJq:?jJ_'>n</variable>
  </variables>
  <block type='variables_set' inline='true' x='29' y='41'>
    <field name='VAR' id='hO\`?kR*XbVn|uJq:?jJ_'>n</field>
    <value name='VALUE'>
      <block type='math_number'>
        <field name='NUM'>1</field>
      </block>
    </value>
    <next>
      <block type='controls_repeat_ext' inline='true'>
        <value name='TIMES'>
          <block type='math_number'>
            <field name='NUM'>3</field>
          </block>
        </value>
        <statement name='DO'>
          <block type='variables_set' inline='true'>
            <field name='VAR' id='hO\`?kR*XbVn|uJq:?jJ_'>n</field>
            <value name='VALUE'>
              <block type='math_arithmetic'>
                <field name='OP'>MULTIPLY</field>
                <value name='A'>
                  <block type='variables_get'>
                    <field name='VAR' id='hO\`?kR*XbVn|uJq:?jJ_'>n</field>
                  </block>
                </value>
                <value name='B'>
                  <block type='math_number'>
                    <field name='NUM'>2</field>
                  </block>
                </value>
              </block>
            </value>
            <next>
              <block type='text_print'>
                <value name='TEXT'>
                  <block type='api_ZArduino_ONLed__led__GET'>
                    <value name='val_led'>
                      <shadow type='math_number'>
                        <field name='NUM'>0</field>
                      </shadow>
                      <block type='variables_get'>
                        <field name='VAR' id='hO\`?kR*XbVn|uJq:?jJ_'>n</field>
                      </block>
                    </value>
                  </block>
                </value>
                <next>
                  <block type='text_print'>
                    <value name='TEXT'>
                      <block type='api_ZArduino_Sleep__minutes__GET'>
                        <value name='val_minutes'>
                          <shadow type='math_number'>
                            <field name='NUM'>0</field>
                          </shadow>
                          <block type='math_arithmetic'>
                            <field name='OP'>MULTIPLY</field>
                            <value name='A'>
                              <block type='variables_get'>
                                <field name='VAR' id='hO\`?kR*XbVn|uJq:?jJ_'>n</field>
                              </block>
                            </value>
                            <value name='B'>
                              <block type='math_number'>
                                <field name='NUM'>2</field>
                              </block>
                            </value>
                          </block>
                        </value>
                      </block>
                    </value>
                    <next>
                      <block type='text_print'>
                        <value name='TEXT'>
                          <block type='api_ZArduino_OFFLed__led__GET'>
                            <value name='val_led'>
                              <shadow type='math_number'>
                                <field name='NUM'>0</field>
                              </shadow>
                              <block type='variables_get'>
                                <field name='VAR' id='hO\`?kR*XbVn|uJq:?jJ_'>n</field>
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
        </statement>
      </block>
    </next>
  </block>
</xml>
`
        },
        {
            name: 'testClassEnumInsideClass',
            data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <variables>
    <variable id="L4n0rEg4Nu/A2g*qJqV(">var_AnEnum</variable>
    <variable id="xLjy%04Y+RuI2K\`Ax8{K">var_Test</variable>
    <variable id=",Bknbj[;TK=[P,-XtwGx">var_WithInsideClass</variable>
  </variables>
  <block type="variables_set" x="81" y="50">
    <field name="VAR" id="L4n0rEg4Nu/A2g*qJqV(">var_AnEnum</field>
    <value name="VALUE">
      <block type="TestBlocklyHtml_Controllers_AnEnum">
        <field name="val_AnEnum">0</field>
      </block>
    </value>
    <next>
      <block type="variables_set">
        <field name="VAR" id="xLjy%04Y+RuI2K\`Ax8{K">var_Test</field>
        <value name="VALUE">
          <block type="TestBlocklyHtml_Controllers_Test">
            <value name="val_Ind">
              <shadow type="text">
                <field name="TEXT">Andrei</field>
              </shadow>
            </value>
            <value name="val_a">
              <block type="variables_get">
                <field name="VAR" id="L4n0rEg4Nu/A2g*qJqV(">var_AnEnum</field>
              </block>
            </value>
          </block>
        </value>
        <next>
          <block type="variables_set">
            <field name="VAR" id=",Bknbj[;TK=[P,-XtwGx">var_WithInsideClass</field>
            <value name="VALUE">
              <block type="TestBlocklyHtml_Controllers_WithInsideClass">
                <value name="val_t">
                  <block type="variables_get">
                    <field name="VAR" id="xLjy%04Y+RuI2K\`Ax8{K">var_Test</field>
                  </block>
                </value>
              </block>
            </value>
            <next>
              <block type="text_print">
                <value name="TEXT">
                  <block type="api_VariousTests_TestInsideVariable_POST">
                    <value name="val_id">
                      <shadow type="TestBlocklyHtml_Controllers_WithInsideClass"></shadow>
                      <block type="variables_get">
                        <field name="VAR" id=",Bknbj[;TK=[P,-XtwGx">var_WithInsideClass</field>
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
            name: "generic",
            data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <variables>
    <variable id="Q|gzJurns)WU=N)C0oZ}">var_AnEnum</variable>
    <variable id="qt^W83W?Bn+2_%*A*V+l">var_Test</variable>
    <variable id="N]NaQUz7^al6M0L[DzFK">var_GenericsTest_1</variable>
  </variables>
  <block type="variables_set" x="68" y="102">
    <field name="VAR" id="Q|gzJurns)WU=N)C0oZ}">var_AnEnum</field>
    <value name="VALUE">
      <block type="TestBlocklyHtml_Controllers_AnEnum">
        <field name="val_AnEnum">1</field>
      </block>
    </value>
    <next>
      <block type="variables_set">
        <field name="VAR" id="qt^W83W?Bn+2_%*A*V+l">var_Test</field>
        <value name="VALUE">
          <block type="TestBlocklyHtml_Controllers_Test">
            <value name="val_Ind">
              <shadow type="text">
                <field name="TEXT">asdads</field>
              </shadow>
            </value>
            <value name="val_a">
              <block type="variables_get">
                <field name="VAR" id="Q|gzJurns)WU=N)C0oZ}">var_AnEnum</field>
              </block>
            </value>
          </block>
        </value>
        <next>
          <block type="variables_set">
            <field name="VAR" id="N]NaQUz7^al6M0L[DzFK">var_GenericsTest_1</field>
            <value name="VALUE">
              <block type="TestBlocklyHtml_Controllers_GenericsTest\`1[[TestBlocklyHtml_Controllers_Test, TestBlocklyHtml, Version=1_0_0_0, Culture=neutral, PublicKeyToken=null]]">
                <value name="val_t">
                  <block type="variables_get">
                    <field name="VAR" id="qt^W83W?Bn+2_%*A*V+l">var_Test</field>
                  </block>
                </value>
              </block>
            </value>
            <next>
              <block type="text_print">
                <value name="TEXT">
                  <block type="api_VariousTests_TestGeneric_POST">
                    <value name="val_id">
                      <shadow type="TestBlocklyHtml_Controllers_GenericsTest\`1[[TestBlocklyHtml_Controllers_Test, TestBlocklyHtml, Version=1_0_0_0, Culture=neutral, PublicKeyToken=null]]"></shadow>
                      <block type="variables_get">
                        <field name="VAR" id="N]NaQUz7^al6M0L[DzFK">var_GenericsTest_1</field>
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
            name: 'array inside class',
            data:`<xml xmlns="https://developers.google.com/blockly/xml">
  <variables>
    <variable id="$sp!v9t+BX;Ji(aw:=kP">var_EmployeeX</variable>
    <variable id="pqiw3n@o%q}kBq,\`bLO~">var_DepartmentX</variable>
  </variables>
  <block type="variables_set" x="261" y="290">
    <field name="VAR" id="$sp!v9t+BX;Ji(aw:=kP">var_EmployeeX</field>
    <value name="VALUE">
      <block type="TestBlocklyHtml_Controllers_EmployeeX">
        <value name="val_Name">
          <shadow type="text">
            <field name="TEXT">NameEmployee</field>
          </shadow>
        </value>
      </block>
    </value>
    <next>
      <block type="variables_set">
        <field name="VAR" id="pqiw3n@o%q}kBq,\`bLO~">var_DepartmentX</field>
        <value name="VALUE">
          <block type="TestBlocklyHtml_Controllers_DepartmentX">
            <value name="val_Name">
              <shadow type="text">
                <field name="TEXT">NameDepartment</field>
              </shadow>
            </value>
            <value name="val_Employees">
              <shadow type="lists_create_with">
                <mutation items="3"></mutation>
              </shadow>
              <block type="lists_create_with">
                <mutation items="1"></mutation>
                <value name="ADD0">
                  <block type="variables_get">
                    <field name="VAR" id="$sp!v9t+BX;Ji(aw:=kP">var_EmployeeX</field>
                  </block>
                </value>
              </block>
            </value>
          </block>
        </value>
        <next>
          <block type="text_print">
            <value name="TEXT">
              <block type="api_VariousTests_TestArray_POST">
                <value name="val_id">
                  <shadow type="TestBlocklyHtml_Controllers_DepartmentX"></shadow>
                  <block type="variables_get">
                    <field name="VAR" id="pqiw3n@o%q}kBq,\`bLO~">var_DepartmentX</field>
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
        }
]



var testBlocks = [

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
        name: 'Get First item from GET REST call',
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
    }
]
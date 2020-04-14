var testBlocks = [

    {
        name: 'Just weather',
        data:`<xml xmlns="https://developers.google.com/blockly/xml">
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
    }]
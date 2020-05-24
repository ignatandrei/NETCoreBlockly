function startIntro() {
            var intro = introJs();
            intro.setOptions({
                steps: [
                    {
                        intro: "Welcome !"
                    },
                    {
                        element: document.querySelector('#blocklyDiv'),
                        intro: "This area is you <b>playground</b> with blocks"
                    },
                    {
                        element: '#runButton',
                        intro: "You can <b>execute</b> blocks by clicking here"
                    },
                    {
                        element: '#output',
                        intro: "And see the <b>result</b> here"
                    },
                    {
                        element: '#saveBlocks',
                        intro: "<b>Save</b> for later use by clicking here"
                    },
                    {
                        element: document.getElementById('blockly:0'),
                        intro: 'Explore <b>more</b> executing blocks here'
                    }
                    ,
                    {
                        element: '#runButton',
                        intro: "After finish this tutorial, click execute"
                    },


                    {

                        intro: 'Click button done or outside to finish the tutorial'
                    }

                ]

            });

            intro.setOption('showProgress', true).start();
        }

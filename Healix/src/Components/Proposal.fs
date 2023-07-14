module Healix.Components.Proposal

open Antidote.Core.V2.Utils.JS
open Feliz
open Feliz.Bulma
open Fable.Core.JsInterop
open Healix.Components.PhysicianOverview
open Fable.Core.JS
open Feliz.Plotly


let private classes : CssModules.Components.Proposal = import "default" "./Proposal.module.scss"

type iconData = {
    Icon: string
    //color: string
    Title: string
    Description: string
}

let heartIcon = {
    Icon = ".././Assets/heart.svg"
    Title = "Framing Heart Risk Score"
    Description = "Leveraging the Framingham Heart Study's model, we enable proactive and precise cardiovascular risk assessment, promoting robust prevention and management."
}

let diabetesIcon = {
    Icon = ".././Assets/diabetes.svg"
    Title = "Diabetes Risk Score"
    Description = "Using the American Diabetes Association's risk tool, we enable accurate prediction and proactive prevention of diabetes, fostering effective management."
}

let charlsonIcon = {
    Icon = ".././Assets/helix.svg"
    Title = "Charlson Comorbidity Index"
    Description = "Leveraging the Charlson Comorbidity Index, we enable accurate prediction of mortality and morbidity, promoting effective management."
}

let ckdIcon = {
    Icon = ".././Assets/kidney.svg"
    Title = "CKD Risk Score"
    Description = "Incorporating the SCORED algorithm for chronic kidney disease, we support renal health, promoting early detection and proactive management of potential kidney-related complications."
}

let copdIcon = {
    Icon = ".././Assets/lungs.svg"
    Title = "CAT Risk Score"
    Description = "Using the American Diabetes Association's risk tool, we enable accurate prediction and proactive prevention of diabetes, fostering effective management."
}

let mentalHealthIcon = {
    Icon = ".././Assets/brain.svg"
    Title = "Mental Health & SDOH Risk Scores"
    Description = "Using PHQ-9, CAGE, DSM5, and our unique SDOH risk score, we provide a holistic strategy for mental and social health, aiding early detection, prevention, and management of conditions."
}

let values =
    [ PlotData.String [ "Reimbursement Base"; "Monthly Premium Increase"; "Average Member LOS"; "Proj. Annual Total"; "Centers";
    "Readjusted Proj" ]
      PlotData.String [ "$526.62"; "$10,005.72"; "12 Mo"; "$120,068"; "35";"$4,202,403" ] ]

let headers =
    [ [ "<b>Labels</b>" ]
      [ "<b>Data</b>" ]
 ]

let table2 () =
    Plotly.plot [
        plot.traces [
            traces.table [
                table.header [
                    header.values headers
                    header.align.center
                    header.line [
                        line.width 1
                        line.color color.black
                    ]
                    header.fill [
                        fill.color color.skyBlue
                    ]
                    header.font [
                        font.family font.arial
                        font.size 17
                        font.color color.white
                    ]
                ]
                table.cells [
                    cells.values values
                    cells.align.center
                    cells.line [
                        line.color color.black
                        line.width 1
                    ]
                    cells.fill [
                        fill.color [
                            [ color.white
                              color.whiteSmoke
                              color.white
                              color.whiteSmoke
                              color.white
                              color.whiteSmoke
                               ]
                        ]
                    ]
                    cells.font [
                        font.family font.arial
                        font.size 13
                        font.color color.black
                    ]
                ]
            ]
        ]
        plot.layout [
            layout.height 350
        ]
    ]

let iconGen (props:iconData) =
    Html.div [
        prop.style [ style.display.flex; style.flexDirection.column; style.width (length.px 500); style.marginTop 15]
        prop.children [
            Html.div [
                prop.style [ style.display.flex; style.justifyContent.center]
                prop.children [
                    Html.img [prop.src props.Icon; prop.style [style.width 50; style.height 50]]
                ]
            ]
            Html.div [
                prop.style [ style.fontWeight.bold; style.textAlign.center]
                prop.children [
                    Html.text props.Title
                ]
            ]
            Html.div [
                prop.style[ style.textAlign.center; style.fontSize 14; style.wordWrap.breakWord] // Set font size and text wrapping
                prop.children [
                    Html.text props.Description
                ]
            ]
        ]
    ]


[<ReactComponent>]
let title () =
    Html.div [
        prop.style [ style.display.flex; style.justifyContent.center; style.backgroundImage "url('.././Assets/animatedbackground.svg')"; style.backgroundRepeat.noRepeat; style.backgroundSize.cover; style.backgroundPosition "center"]
        prop.children [
            Html.div [
                prop.style [style.textAlign.center; style.display.flex]
                prop.children [
                    Html.div [
                        prop.style [ ] // Set the background image here
                        prop.children [
                            Html.img [prop.src ".././Assets/logo.svg"]
                            Html.div [
                                prop.style [ style.fontSize 25; style.color "#1D1D1D"; style.marginTop -60; style.marginBottom 10; style.color.black; style.fontWeight.bold]
                                prop.children [
                                    Html.span "Physician Care Center's Proposal"
                                ]
                            ]
                            Html.div [
                                prop.style [ style.fontSize 17; style.color.white; style.marginBottom 10;style.fontWeight 390]
                                prop.children [
                                    Html.span "12/23/2023"
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]


let logicIcon = {
    Icon = ".././Assets/logicengine.svg"
    Title = "Logic Engine"
    Description = "Create deep automated workflows ran on user specified triggers."
}

let gptIcon = {
    Icon = ".././Assets/ai2.svg"
    Title = "Chat GPT Integration"
    Description = "Leverage the AI power of Chat GPT for patient engagement to data driven outcomes"
}

let hipaaIcon = {
    Icon = ".././Assets/hipaa.svg"
    Title = "HIPAA Compliant"
    Description = "Secure HIPAA compliant software."
}

let icdIcon = {
    Icon = ".././Assets/ai.svg"
    Title = "ICD 10 AI Generator"
    Description = "Synthesize clinical documentation and output diagnosis codes."
}

let userIcon = {
    Icon = ".././Assets/useranalytics.svg"
    Title = "User Analytics"
    Description = "Unlock the power of user analytics to gain valuable insights into patient insights and drive data-informed decision-making for your patient care."
}

let designIcon = {
    Icon = ".././Assets/clean design.svg"
    Title = "Clean Design"
    Description = "Visually appealing user experience that enhances usability, efficiency, and overall satisfaction for healthcare professionals, organizations, and patients."
}

let scope =
    Html.div [
        prop.style [style.display.flex; style.flexDirection.column; style.justifyContent.left]
        prop.children [
            Html.div [
                prop.children [
                    Html.div [
                        prop.children [
                            Html.div [
                                prop.style [style.textAlign.center; style.fontSize 25; style.color "#1D1D1D"; style.marginTop 20;style.fontWeight.bold]
                                prop.children [
                                    Html.text "Features"
                                ]
                            ]
                            Html.div [
                                prop.style [style.textAlign.center; style.fontSize 15; style.color "#1D1D1D"; style.marginTop 5; style.marginBottom 20]
                                prop.children [
                                    Html.text "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor."
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex; style.flexWrap.wrap; style.justifyContent.center]
                        prop.children [
                            iconGen (logicIcon)
                            iconGen (gptIcon)
                            iconGen (hipaaIcon)
                            iconGen (icdIcon)
                            iconGen (userIcon)
                            iconGen (designIcon)
                        ]
                    ]
                ]
            ]
        ]
    ]


let hedisIcon = {
    Icon = ".././Assets/HEDIS.svg"
    Title = "Framing Heart Risk Score"
    Description = "Leveraging the Framingham Heart Study's model, we enable proactive and precise cardiovascular risk assessment, promoting robust prevention and management."
}

let cahpsIcon = {
    Icon = ".././Assets/CAHPS.svg"
    Title = "Diabetes Risk Score"
    Description = "Using the American Diabetes Association's risk tool, we enable accurate prediction and proactive prevention of diabetes, fostering effective management."
}

let socialDeterminantsIcon = {
    Icon = ".././Assets/SocialDeterminants.svg"
    Title = "Charlson Comorbidity Index"
    Description = "Leveraging the Charlson Comorbidity Index, we enable accurate prediction of mortality and morbidity, promoting effective management."
}

let icd10_Capture = {
    Icon = ".././Assets/Icd10_Capture.svg"
    Title = "CKD Risk Score"
    Description = "Incorporating the SCORED algorithm for chronic kidney disease, we support renal health, promoting early detection and proactive management of potential kidney-related complications."
}


let effectiveIn =
    Html.div [
        prop.style [style.display.flex; style.flexDirection.column; style.justifyContent.left]
        prop.children [
            Html.div [
                prop.children [
                    Html.div [
                        prop.children [
                            Html.div [
                                prop.style [style.textAlign.center; style.fontSize 25; style.color "#1D1D1D"; style.marginTop 20;style.fontWeight.bold]
                                prop.children [
                                    Html.text "Effective In"
                                ]
                            ]
                            Html.div [
                                prop.style [style.textAlign.center; style.fontSize 15; style.color "#1D1D1D"; style.marginTop 5; style.marginBottom 20]
                                prop.children [
                                    Html.text "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor."
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex; style.flexWrap.wrap; style.justifyContent.center]
                        prop.children [
                            iconGen (hedisIcon)
                            iconGen (cahpsIcon)
                            iconGen (socialDeterminantsIcon)
                            iconGen (icd10_Capture)
                        ]
                    ]
                ]
            ]
        ]
    ]

let predictiveModels =
    Html.div [
        prop.style [style.display.flex; style.flexDirection.column; style.justifyContent.left; style.backgroundImage "url('.././Assets/blur.svg')"; style.backgroundRepeat.noRepeat; style.backgroundSize.cover; style.backgroundPosition "center"]
        prop.children [
            Html.div [
                prop.children [
                    Html.div [
                        prop.children [
                            Html.div [
                                prop.style [style.textAlign.center; style.fontSize 25; style.color "#1D1D1D"; style.marginTop 20;style.fontWeight.bold]
                                prop.children [
                                    Html.text "Predictive Models"
                                ]
                            ]
                            Html.div [
                                prop.style [style.textAlign.center; style.fontSize 15; style.color "#1D1D1D"; style.marginTop 5; style.marginBottom 20]
                                prop.children [
                                    Html.text "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor."
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex; style.flexWrap.wrap; style.justifyContent.center]
                        prop.children [
                            iconGen (heartIcon)
                            iconGen (copdIcon)
                            iconGen (mentalHealthIcon)
                            iconGen (diabetesIcon)
                            iconGen (ckdIcon)
                            iconGen (charlsonIcon)
                        ]
                    ]
                ]
            ]
        ]
    ]

let table =
    Html.div [
        prop.className "container"
        prop.children [
            Html.table [
                Html.thead [
                    Html.tr [
                        Html.th "Column 1"
                        Html.th "Column 2"
                        Html.th "Column 3"
                        Html.th "Column 4"
                        Html.th "Column 5"
                    ]
                ]
                Html.tbody [
                    Html.tr [
                        Html.td "Cell 1"
                        Html.td "Cell 2"
                        Html.td "Cell 3"
                        Html.td "Cell 4"
                        Html.td "Cell 5"
                    ]
                    Html.tr [
                        Html.td "Cell 1"
                        Html.td "Cell 2"
                        Html.td "Cell 3"
                        Html.td "Cell 4"
                        Html.td "Cell 5"
                    ]
                    Html.tr [
                        Html.td "Cell 1"
                        Html.td "Cell 2"
                        Html.td "Cell 3"
                        Html.td "Cell 4"
                        Html.td "Cell 5"
                    ]
                    Html.tr [
                        Html.td "Cell 1"
                        Html.td "Cell 2"
                        Html.td "Cell 3"
                        Html.td "Cell 4"
                        Html.td "Cell 5"
                    ]
                    Html.tr [
                        Html.td "Cell 1"
                        Html.td "Cell 2"
                        Html.td "Cell 3"
                        Html.td "Cell 4"
                        Html.td "Cell 5"
                    ]
                ]
            ]
        ]
    ]

let caseStudy =
    Html.div [
        prop.style [style.display.flex; style.flexDirection.row; style.flexWrap.wrap; style.justifyContent.spaceAround]
        prop.children [
            Html.div [
                prop.children [
                    Html.div [
                        prop.children [
                            Html.div [
                                prop.style [style.textAlign.center; style.fontSize 25; style.color "#1D1D1D"; style.marginTop 20;style.fontWeight.bold]
                                prop.children [
                                    Html.text "Major Depressive Disorder Case Study"
                                ]
                            ]
                            Html.div [
                                prop.style [style.textAlign.center; style.fontSize 15; style.color "#1D1D1D"; style.marginTop 5; style.marginBottom 20]
                                prop.children [
                                    Html.text "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor."
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.style [style.display.flex; style.flexDirection.row; style.justifyContent.spaceAround; style.flexWrap.wrap]
                        prop.children [
                            Html.div [
                                //prop.className [classes.widthFifty]
                                prop.children [
                                    Html.div [
                                        prop.style [style.textAlign.center; style.fontSize 25; style.color "#1D1D1D"; style.marginTop 20;style.fontWeight.bold]
                                        prop.children [
                                            Html.text "Overview "
                                        ]
                                    ]
                                    Html.div [
                                        prop.style [style.textAlign.center]
                                        prop.children [
                                            Html.text "This case study focuses on a pilot program conducted in Medicare Advantage clinics to evaluate the use of the PHQ-9 questionnaire for screening major depressive disorder (MDD) in elderly patients. The objective was to assess the feasibility and effectiveness of integrating the PHQ-9 screening tool into routine clinic workflows. The study involved training clinic staff to administer the PHQ-9 questionnaire and collect data from elderly participants. Preliminary results indicated that the integration of PHQ-9 screening was feasible and acceptable to both staff and patients. The questionnaire effectively identified individuals at risk for MDD, enabling early intervention and treatment referral. Challenges included staff training and ensuring consistent administration of the PHQ-9. Overall, the pilot program demonstrated promising outcomes, supporting the potential implementation of PHQ-9 screening in Medicare Advantage clinics for improved detection and management of MDD among elderly patients."
                                        ]
                                    ]

                                ]
                            ]
                            Html.div [
                                //prop.className [classes.widthFifty]
                                prop.children [
                                    Plotly.plot [
                                        plot.traces [
                                            traces.pie [
                                                pie.values [ 19; 42]
                                                pie.labels [ "Positive"; "Negative"]
                                            ]
                                        ]
                                        plot.layout [
                                            layout.height 400
                                            layout.width 500
                                        ]
                                    ]

                                ]
                            ]
                            Html.div [
                                prop.children [
                                    table2()
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]

type Step =
    | Step1
    | Step2
    | Step3

[<ReactComponent>]
let steps () =
    let (currentStep, setStep) = React.useState Step.Step1

    let stepImage = match currentStep with
        | Step1 -> Html.img [prop.src "../Assets/step1.png"; prop.style [style.width 300; style.height 300]]
        | Step2 -> Html.img [prop.src "../Assets/step2.png"; prop.style [style.width 300; style.height 300]]
        | Step3 -> Html.img [prop.src "../Assets/step3.png"; prop.style [style.width 300; style.height 300]]

    // Text for each step
    let stepText = match currentStep with
        | Step1 -> "Upload Patient Rosters"
        | Step2 -> "Some text for Step 2"
        | Step3 -> "Some text for Step 3"

    let stepDesc = match currentStep with
        | Step1 -> "Utilizing the power of our advanced models and cutting-edge technology, we have the capability to efficiently process and upload patient rosters within an impressively short timeframe of just one day. With our streamlined processes and optimized algorithms, we ensure swift and accurate handling of the data."
        | Step2 -> "Setup what you want to be sent out to patients. We have templates forms that you can start using immediately."
        | Step3 -> "Our user-friendly dashboards offer a comprehensive suite of tools designed to effortlessly monitor and evaluate results, enabling businesses to gain valuable insights and effectively track their return on investment (ROI)."

    Html.div [
        prop.style [style.display.flex; style.flexDirection.row; style.justifyContent.spaceAround; style.flexWrap.wrap; ]
        prop.children [
            Html.div [
                //prop.style [style.borderRight(1, borderStyle.solid, color.lightGray)]
                prop.children [
                    stepImage // Display the image for the current step
                ]
            ]
            Html.div [
                prop.children [
                    Html.div [
                        prop.children [
                            Bulma.tabs [
                                tabs.isCentered
                                prop.className [classes.circularTabs]  // Here
                                prop.children [
                                    Html.ul [
                                        Bulma.tab [
                                            //prop.className [classes.circularTab]  // Here
                                            prop.children [
                                                Html.a [
                                                prop.text "Step 1"
                                                prop.onClick (fun _ -> setStep Step1)
                                            ]
                                            ]
                                        ]
                                        Bulma.tab [
                                            //prop.className [classes.circularTab] // And here
                                            prop.children [
                                                Html.a [
                                                prop.text "Step 2"
                                                prop.onClick (fun _ -> setStep Step2)
                                            ]
                                            ]
                                        ]
                                        Bulma.tab [
                                            //prop.className [classes.circularTab] // And here
                                            prop.children [
                                                Html.a [
                                                prop.text "Step 3"
                                                prop.onClick (fun _ -> setStep Step3)
                                            ]
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]

                    Html.div [
                        prop.style [style.textAlign.center; style.fontSize 25; style.color "#1D1D1D"; style.marginTop 20;style.fontWeight.bold]
                        prop.children [
                            Html.text stepText // Render the text for the current step
                        ]
                    ]
                    Html.div [
                        prop.style [style.textAlign.center; style.fontSize 15; style.color "#1D1D1D"; style.marginTop 5; style.marginBottom 20; style.padding 20; style.maxWidth 600]
                        prop.children [
                            Html.text stepDesc // Render the text for the current step
                        ]
                    ]
                ]
            ]
        ]
    ]





// PhysicianIcons (reviewsIcon)
let Proposal () =
    Html.div [
        prop.children [
            title ()
            //scope
            steps ()
            //effectiveIn
            //predictiveModels
            //table
            //caseStudy
        ]
    ]

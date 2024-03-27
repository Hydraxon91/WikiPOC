const PresetCardComponent = ({stylePreset}) =>{
    return(
        <div className="wikipage-preset-component" style={{ backgroundColor: stylePreset.bodyColor, fontFamily: stylePreset.fontFamily}}>
            <div className="article-right-preset" style={{ backgroundColor: stylePreset.articleRightColor }}>
                  <div className="article-right-inner-preset" style={{ backgroundColor: stylePreset.articleRightInnerColor }}>
                    <img className='paragraphImage'  alt="logo" />
                  </div>
                  {"This is a text"}      
            </div>
            <div className={"wikipage-content-container"}>Content of the 1st Paragraph</div>
            <h2>Paragraph 2 Title</h2>
            <div className={"wikipage-content-container"}>Content of the 2nd Paragraph</div>
            <h2>Paragraph 3 Title</h2>
            <div className={"wikipage-content-container"}>Content of the 3rd Paragraph</div>
            <div className="pagefooter-template" style={{ color: stylePreset.footerListTextColor }}>
                This is a footer
                <div className="footerlinks"> 
                    <a href="#" style={{ color: stylePreset.footerListLinkTextColor }} >Privacy policy</a>
                </div>
            </div>
        </div>
    )
}

export default PresetCardComponent;
import { useState } from 'react';

const WikiStyles = () => {
  const [logo, setLogo] = useState('/img/logo.png');
  const [wikiName, setWikiName] = useState('Your Wiki');
  const [bodyColor, setBodyColor] = useState('#507ced');
  const [articleRightColor, setArticleRightColor] = useState('#3c5fb8');
  const [articleRightInnerColor, setArticleRightInnerColor] = useState('#2b4ea6');
  const [articleColor, setArticleColor] = useState('#526cad');
  const [footerListLinkTextColor, setFooterListLinkTextColor] = useState('#1d305e');
  const [footerListTextColor, setFooterListTextColor] = useState('#233a71');

  return {
    logo, setLogo,
    wikiName, setWikiName,
    bodyColor, setBodyColor,
    articleRightColor, setArticleRightColor,
    articleRightInnerColor, setArticleRightInnerColor,
    articleColor, setArticleColor,
    footerListLinkTextColor, setFooterListLinkTextColor,
    footerListTextColor, setFooterListTextColor,
  };
};

export default WikiStyles;
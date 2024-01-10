import React, { createContext, useContext, useState } from 'react';

const StyleContext = createContext();

export const StyleProvider = ({ children }) => {
  const [styles, setStyles] = useState({
    logo: '/img/logo.png',
    wikiName: 'Your Wiki',
    bodyColor: '#507ced',
    articleRightColor: '#3c5fb8',
    articleRightInnerColor: '#2b4ea6',
    articleColor: '#526cad',
    footerListLinkTextColor: '#1d305e',
    footerListTextColor: '#233a71',
  });

  const updateStyles = (newStyles) => {
    setStyles((prevStyles) => ({ ...prevStyles, ...newStyles }));
  };

  return (
    <StyleContext.Provider value={{ styles, updateStyles }}>
      {children}
    </StyleContext.Provider>
  );
};

export const useStyleContext = () => {
    const context = useContext(StyleContext);
    if (!context) {
      throw new Error('useStyleContext must be used within a StyleProvider');
    }
    return context;
  };
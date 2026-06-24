import React, { createContext, useContext, useState } from 'react';
import { UserContextType } from '../../types/contexts';

const UserContext = createContext<UserContextType>({} as UserContextType);

export const UserContextProvider = ({ children }) => {
  const [decodedTokenContext, setDecodedTokenContext] = useState(null);
  const updateUser = (newUser) => {
    setDecodedTokenContext(newUser);
  };

  return (
    <UserContext.Provider value={{ decodedTokenContext, updateUser }}>
      {children}
    </UserContext.Provider>
  );
};

export const useUserContext = () => {
  const context = useContext(UserContext);
  if (!context) {
    throw new Error('useUserContext must be used within a UserContextProvider');
  }
  return context;
};
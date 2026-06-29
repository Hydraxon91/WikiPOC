import { ReactNode, Dispatch, SetStateAction } from 'react';

export interface StyleModel {
  logo?: string;
  wikiName?: string;
  bodyColor?: string;
  articleColor?: string;
  articleRightColor?: string;
  articleRightInnerColor?: string;
  footerListLinkTextColor?: string;
  footerListTextColor?: string;
  fontFamily?: string;
}

export interface StyleContextType {
  styles: StyleModel;
  setStyles: Dispatch<SetStateAction<StyleModel>>;
  updateStyles: (styles: StyleModel, logo?: File | null, jwtToken?: string) => void;
}

export interface DecodedToken {
  sub: string;
  jti: string;
  iat: number;
  name: string;
  email: string;
  role: string;
  nameidentifier: string;
  exp: number;
  iss: string;
  aud: string;
}

export interface UserContextType {
  decodedTokenContext: DecodedToken | null;
  updateUser: (token: DecodedToken | null) => void;
}

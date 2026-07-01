import { ReactNode, Dispatch, SetStateAction } from 'react';
import { StyleModel } from './models';

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

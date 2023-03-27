import React, { createContext } from 'react';
import useDialog from '../shared/hooks/useDialog';
import { DialogContextProps } from '../shared/interfaces/DialogInterface';
import Dialog from '../shared/components/dialog';

export const DialogContext = createContext({} as DialogContextProps);

type Props = {
    children: React.ReactNode;
  };

const DialogProvider = ({ children }: Props): JSX.Element => {
  const { isDialog, setDialog, dialogContent, dialogConfig } = useDialog();
  
return (
    <DialogContext.Provider value={{ isDialog, setDialog, dialogContent, dialogConfig }}>
      <Dialog />
      {children}
    </DialogContext.Provider>
  );
};

export default DialogProvider;

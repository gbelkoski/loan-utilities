import { useState } from 'react';
import { DialogConfigInterface, DialogContextProps } from '../interfaces/DialogInterface';

export default (): DialogContextProps => {
  const [isDialog, toggleDialog] = useState<boolean>(false);
  const [dialogContent, setDialogContent] = useState<JSX.Element | null>(null);
  const [dialogConfig, setDialogConfig] = useState<DialogConfigInterface>({
    isBackdropClickable: false,
    isCloseButton: true,
  })

  const setDialog = (content?: JSX.Element, config?: DialogConfigInterface): void => {
    if (!content) {
      toggleDialog(false);
    } else {
      toggleDialog(true);
      setDialogContent(content);
    }

    if (config) {
      setDialogConfig({
        ...dialogConfig,
        ...config
      })
    }
  };

  return { isDialog, setDialog, dialogContent, dialogConfig };
};

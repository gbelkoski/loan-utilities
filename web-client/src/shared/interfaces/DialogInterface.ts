export interface DialogConfigInterface {
    isBackdropClickable: boolean;
    isCloseButton: boolean;
  }
  
  export interface DialogContextProps {
    isDialog: boolean;
    setDialog: (content?: JSX.Element, config?: DialogConfigInterface) => void;
    dialogContent: React.ReactNode;
    dialogConfig: DialogConfigInterface;
  }
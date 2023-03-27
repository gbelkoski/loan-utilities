import React, { useContext } from 'react';
import { makeStyles, Dialog,  Theme } from '@material-ui/core';
import { DialogContext } from '../../context/dialogContext';
import CancelIcon from '@material-ui/icons/Cancel';

const useStyles = makeStyles((theme: Theme) => ({
  closeIcon: {
    backgroundColor: 'black',
    borderRadius: '50%',
    color: theme.palette.grey['300'],
    cursor: 'pointer',
    height: '1.6rem',
    position: 'absolute',
    right: '-40px',
    top: 0,
    width: '1.6rem',
    '& path': {
      transform: 'scale(1.35)',
      transformOrigin: 'center',
    }
  },
  paper: {
    overflow: 'visible'
  }
}));

const DialogComponent = (): JSX.Element => {
  const classes = useStyles();
  const { dialogContent, dialogConfig, setDialog, isDialog } = useContext(DialogContext);

  const handleOnCancelClick = (): void => setDialog();

  return (
    <>
    {isDialog && (
      <Dialog
        disableBackdropClick={!dialogConfig.isBackdropClickable}
        disableEscapeKeyDown={!dialogConfig.isBackdropClickable}
        onClose={handleOnCancelClick}
        aria-labelledby="dialog"
        open={isDialog}
        classes={{
          paper: classes.paper
        }}
      >
        {dialogContent}
        {dialogConfig.isCloseButton && <CancelIcon className={classes.closeIcon} onClick={handleOnCancelClick} />}
      </Dialog>
    )}
    </>
  )
}

export default DialogComponent;

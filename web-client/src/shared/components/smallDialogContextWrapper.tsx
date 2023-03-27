import React, { useContext } from 'react';
import { makeStyles, Typography, Grid, Theme } from '@material-ui/core';
import { DialogContext } from '../../context/dialogContext';
import StyledButton from './styledButton';
import ButtonGroup from './buttonGroup';

type Props = {
  handleClose?: () => void;
  handleConfirm?: () => void;
  icon?: React.ReactNode;
  title: React.ReactNode;
  message: React.ReactNode;
  cancelButtonText?: React.ReactNode;
  submitButtonText?: React.ReactNode;
}

const useStyles = makeStyles((theme: Theme) => ({
  container: {
    maxWidth: `10px`,
    padding: theme.spacing(4, 3.5, 2)
  },
  icon: {
    display: 'flex'
  },
  text: {
    padding: theme.spacing(3, 0, 11)
  },
  title: {
    lineHeight: 2,
  }
}));

const SmallDialogContentWrapper = ({
  handleConfirm,
  icon,
  title,
  message,
  cancelButtonText,
  submitButtonText,
}: Props): JSX.Element => {
  const classes = useStyles();
  const { setDialog } = useContext(DialogContext);

  const handleOnCancelClick = (): void => setDialog();

  return (
    <Grid container className={classes.container}>
      <Grid item xs={12} className={classes.icon}>
        {icon}
      </Grid>
      <Grid item xs={12} className={classes.text}>
        <Typography variant="h1" className={classes.title}>
          {title}
        </Typography>
        <Typography>
          {message}
        </Typography>
      </Grid>
      <Grid item xs={12}>
        <ButtonGroup>
          <StyledButton onClick={handleOnCancelClick}>
            {cancelButtonText}
          </StyledButton>
          {handleConfirm && 
          <StyledButton onClick={handleConfirm} styleType="submit">
            {submitButtonText}
          </StyledButton>}
        </ButtonGroup>
      </Grid>
    </Grid>
  )
}

export default SmallDialogContentWrapper;

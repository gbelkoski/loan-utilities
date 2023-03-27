import React from 'react';
import { makeStyles, Theme } from '@material-ui/core';
import ErrorIcon from '@material-ui/icons/Error';
import { FormattedMessage } from 'react-intl';
import SmallDialogContentWrapper from '../components/smallDialogContextWrapper';

const useStyles = makeStyles((theme: Theme) => ({
  icon: {
    color: theme.palette.error.main,
    position: 'relative',
    top: '-4px',
    left: '-4px',
    fontSize: '2rem'
  },
  iconWrapper: {
    borderRadius: '50%',
    borderColor:  theme.palette.error.main,
    borderWidth: 4,
    borderStyle: 'solid',
    display: 'inline-block',
    width: 32,
    height: 32,
  },
}));

interface ErrorDialogProps {
    title: string;
    message: string;
}

const ErrorDialog = (props: ErrorDialogProps): JSX.Element => {
  const classes = useStyles();

  return (
    <SmallDialogContentWrapper
        cancelButtonText = {(
            <FormattedMessage
                defaultMessage="OK"
                id="OK"
            />
        )}
        icon={(
            <span className={classes.iconWrapper}>
                <ErrorIcon className={classes.icon} />
            </span>
        )}
        title={props.title}
        message={props.message}
    />
  )
}

export default ErrorDialog;

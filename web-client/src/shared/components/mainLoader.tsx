import React from 'react';
import { makeStyles, createStyles } from '@material-ui/core';
import CircularProgress from '@material-ui/core/CircularProgress';

const useStyles = makeStyles(() =>
  createStyles({
    root: {
      position:'absolute',
      top:'50%',
      left:'50%'
    },
  }),
);

export default function MainLoader(): JSX.Element {
  const classes = useStyles();

  return <CircularProgress className={classes.root} />
}
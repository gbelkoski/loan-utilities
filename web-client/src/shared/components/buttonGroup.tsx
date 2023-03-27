import React from 'react';
import { makeStyles, Theme, Box, BoxProps } from '@material-ui/core';


interface Props extends BoxProps {
  children: React.ReactNode;
}

const useStyles = makeStyles((theme: Theme) => ({
  buttonGroup: {
    padding: theme.spacing(1, 0),
    '& >*:not(:last-child)': {
      marginRight: theme.spacing(1.5)
    }
  }
}));

const StyledButton = ({ children, ...props }: Props): JSX.Element => {
  const classes = useStyles();

  return (
    <Box
      display="flex"
      justifyContent="flex-end"
      alignSelf="flex-end"
      className={classes.buttonGroup}
      {...props}
    >
      {children}
    </Box>
  )
}

export default StyledButton;

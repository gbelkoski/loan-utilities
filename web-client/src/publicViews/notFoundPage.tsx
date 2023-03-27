import { Container, makeStyles } from '@material-ui/core';
import React from 'react';

const useStyles = makeStyles(() => ({
  root: {
    position: "relative",
    backgroundColor:"white",
    marginTop:30
  }
}));

const NotFoundPage: React.FC = () => {
    const classes = useStyles();
    return (
      <Container className={classes.root}>
        <div>
          <br/>
          <h3>КРЕДИТ-ИНФО е вашиот личен финансиски советник!</h3>
        </div>
      </Container> 
      )
}

export default NotFoundPage;
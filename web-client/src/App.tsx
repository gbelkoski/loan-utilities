import React, { Fragment } from 'react';
import { Container } from '@material-ui/core';
import CssBaseline from '@material-ui/core/CssBaseline';
import { makeStyles } from '@material-ui/core/styles';
import {
    BrowserRouter as Router,
    Route,
    RouteComponentProps,
    Switch
  } from 'react-router-dom';
import Header from "./layout/Header";
import { PublicRoutes } from './routeConfig/routes';
import { globalStyles } from './themes/globalStyles';

const useStyles = makeStyles({
  root:{
    backgroundColor:globalStyles.palette.sideBg,
    minHeight:'100vh'
  },
  container:{
    marginTop: '3em'
  },
  footer:{
    backgroundColor:"#1a3442",
    bottom:"0",
    color:"white",
    width:"100%",
    display:"flex",
    textAlign:"center"
  }
});

declare global {
  interface Window { ENV: any; }
}

window.ENV = window.ENV || {};

const App: React.FC = () => {
  const classes = useStyles();

    return (
        <Container className={classes.root} disableGutters maxWidth={false}>
            { <Header /> }
              <Switch>
                {PublicRoutes}
              </Switch>
            <footer className={classes.footer}>
              <h5>@Сите права се задржани</h5>
              <p>
                КРЕДИТИНФО.МК прикажува јавно достапни податоци, не гарантира за точноста на информациите и не презема одговорност за евентуални грешки во пресметките. За да добиете официјална информација за кредитот притиснете на «Побарај Понуда»
              </p>
            </footer>
        </Container>
    )
}

const StylesWrap: React.FC<RouteComponentProps> = () => {
    return (
      <Fragment>
        <CssBaseline/>
        <App />
      </Fragment>
    );
  };
  
  const RouterWrap: React.FC = () => {
    return (
      <Router>
        <Route component={StylesWrap} />
      </Router>
    );
  };
  
  export default RouterWrap;
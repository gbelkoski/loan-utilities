import {
  Card,
  CardActionArea,
  CardContent,
  Grid,
  makeStyles,
  Typography,
} from "@material-ui/core";
import React from "react";
import landingImg from "../assets/img/landing/banner.svg";
import stanbenImg from "../assets/img/landing/stanben.png";
import potrosuvackiImg from "../assets/img/landing/potrosuvacki.png";
import ostanatiImg from "../assets/img/landing/avto.png";
import { Link } from "react-router-dom";

const useStyles = makeStyles(() => ({
  root: {
    position: "relative",
  },
  landingHeader: {
    height: "380px",
    backgroundRepeat: "no-repeat",
    backgroundSize: "cover",
    borderColor: "black",
    borderStyle: "solid",
    borderTop: "none",
    borderLeft: "none",
    borderRight: "none",
    borderWidth: "2px",
    backgroundImage: `url(${landingImg})`,
  },
  cardContainer: {
    textAlign: "center",
    paddingTop:"2em",
    paddingLeft:10,
    paddingRight:10
  },
  card: {
    borderColor: "#EB7D46",
    border: 1,
    margin:5,
    flex:"1,1,auto",
    flexGrow:1
  },
  loanTypeImage: {
    height: 140,
    weight: 140,
    border:1
  },
  loanTypeLabel: {
    color: "#0f5f8f",
  },
}));

const LandingPage: React.FC = () => {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <header className={classes.landingHeader}/>

      <Grid
        container
        justify="space-around"
        className={classes.cardContainer}
      >
        <Link to="/loans" className={classes.card}>
          <Card>
            <CardActionArea>
              <img src={stanbenImg} className={classes.loanTypeImage} alt="stanben" />
              <CardContent>
                <Typography
                  gutterBottom
                  className={classes.loanTypeLabel}
                >
                  Станбени кредити
                </Typography>
              </CardContent>
            </CardActionArea>
          </Card>
        </Link>

        <Link to="/loans" className={classes.card}>
          <Card>
            <CardActionArea>
              <img src={potrosuvackiImg} className={classes.loanTypeImage} alt="potrosuvacki" />
              <CardContent>
                <Typography
                  gutterBottom
                  className={classes.loanTypeLabel}
                >
                  Потрошувачки кредити
                </Typography>
              </CardContent>
            </CardActionArea>
          </Card>
        </Link>

        <Link to="/loans" className={classes.card}>
          <Card>
            <CardActionArea>
              <img src={ostanatiImg} className={classes.loanTypeImage} alt="ostanati" />
              <CardContent>
                <Typography
                  gutterBottom
                  className={classes.loanTypeLabel}
                >
                  Останати кредити
                </Typography>
              </CardContent>
            </CardActionArea>
          </Card>
        </Link>

      </Grid>
    </div>
  );
};

export default LandingPage;

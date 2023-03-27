import { Button, Container, FormControl, FormGroup, FormHelperText, Grid, Input, InputLabel, makeStyles } from '@material-ui/core';
import React from 'react';

const useStyles = makeStyles(() => ({
  root: {
    backgroundColor:"white",
    marginTop:50
  },
  formControl: {
    marginRight:10
  }
}));

const LoansPage: React.FC = () => {
    const classes = useStyles();
    return (
      <Container className={classes.root}>
        <FormGroup row>
            <FormControl className={classes.formControl}>
                <InputLabel htmlFor="loan-amount">Износ</InputLabel>
                <Input id="loan-amount" aria-describedby="loan-amount-helper" />
                <FormHelperText id="loan-amount-helper">Износ на кредитот</FormHelperText>
            </FormControl>

            <FormControl>
                <InputLabel htmlFor="loan-duration">Времетрење</InputLabel>
                <Input id="loan-duration" aria-describedby="loan-duration-helper" />
                <FormHelperText id="loan-duration-helper">Рок во години</FormHelperText>
            </FormControl>
            <Button variant="contained" color="primary" type='submit'>Пресметај</Button>
        </FormGroup>
      </Container>
      )
}

export default LoansPage;
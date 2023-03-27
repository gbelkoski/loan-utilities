import React, { useState } from 'react';
import { Button, TextField, Grid, Icon, CardContent, Card, makeStyles, Divider, FormControl } from '@material-ui/core';
import { Controller, useForm } from 'react-hook-form';
import useRequest from '../shared/hooks/useRequest';
import { publicApi } from '../httpClient/publicApi';
import endpoints from '../httpClient/endpoints';
import MainLoader from '../shared/components/mainLoader';

const useStyles = makeStyles(() => ({
    card: {
      position: 'relative',
      paddingRight: 50,
      paddingLeft: 50,
      paddingTop:30,
      marginTop:20
    },
    formControl: {
      marginBottom: 20
    },
    title: {
      width: '90%',
    },
    sendButton: {
      margin: '0px 20px 20px 20px',
      width: 150,
      alignSelf: 'flex-end'
    },
    info: {
      display: 'flex',
      padding: '10px',
      marginTop: '45%',
      border: '1px solid #E0E0E0',
      borderRadius: 6,
    },
    label: {
      color: '#D2D2D2',
    },
  }));

const ContactPage: React.FC = () => {
    const classes = useStyles()
    const [isSendingEmail, setIsSendingEmail] = useState<boolean>(false);
    const { handleSubmit, control, errors: fieldsErrors } = useForm({
      mode: 'onBlur',
      reValidateMode: 'onBlur'
    });

    const contactUsApiRequest = useRequest<string>({
      api:publicApi,
      method:'post'
    });

    const handlePost = (data: any) => {
      var rBody = JSON.parse(JSON.stringify(data))
      setIsSendingEmail(true);
      (async function sendContactMailAsync(): Promise<void> {
        var response = await contactUsApiRequest.request(
          endpoints.public.contactus, 
          rBody
        );
        console.log(contactUsApiRequest);
        console.log(response);
        setIsSendingEmail(false);
      })();
    };
    
    return (
        <Card className={classes.card} elevation={3}>
          <CardContent>
          {isSendingEmail ?
          <MainLoader /> : <></>}
            <form onSubmit={handleSubmit(handlePost)}>
              <Grid
                  container
                  direction="column"
                  justify="center"
                  alignItems="stretch"
                  spacing={3}
                  >
                  <h2>Прати ни мејл:</h2>
                  <Divider />
                  <hr/>

                  <FormControl fullWidth variant="outlined">
                    <Controller
                      name="name"
                      as={
                        <TextField
                          id="name"
                          label="Вашето име..." 
                          className={classes.formControl}
                          helperText={fieldsErrors.name ? fieldsErrors.name.message : null}
                          variant="outlined"
                          error={fieldsErrors.name}
                        />
                      }
                      control={control}
                      defaultValue=""
                      rules={{
                        required: 'Името е задолжително'
                      }}
                    />
                  </FormControl>

                  <FormControl fullWidth variant="outlined">
                    <Controller
                      name="email"
                      as={
                        <TextField
                          id="email"
                          label="Вашиот мејл..." 
                          className={classes.formControl}
                          helperText={fieldsErrors.email ? fieldsErrors.email.message : null}
                          variant="outlined"
                          error={fieldsErrors.email}
                        />
                      }
                      control={control}
                      defaultValue=""
                      rules={{
                        required: 'Мејлот е задолжителен',
                        pattern: {
                          value: /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i,
                          message: 'Мејлот не е валиден'
                        }
                      }}
                    />
                  </FormControl>

                  <FormControl fullWidth variant="outlined">
                    <Controller
                      name="phone"
                      as={
                        <TextField
                          id="phone"
                          label="Вашиот телефон..." 
                          className={classes.formControl}
                          helperText={fieldsErrors.phone ? fieldsErrors.phone.message : null}
                          variant="outlined"
                          error={fieldsErrors.phone}
                        />
                      }
                      control={control}
                      defaultValue=""
                    />
                  </FormControl>

                  <FormControl fullWidth variant="outlined">
                    <Controller
                      name="content"
                      as={
                        <TextField
                          id="content"
                          multiline 
                          rows={4} 
                          label="Содржина на пораката..." 
                          className={classes.formControl}
                          helperText={fieldsErrors.content ? fieldsErrors.content.message : null}
                          variant="outlined"
                          error={fieldsErrors.content}
                        />
                      }
                      control={control}
                      defaultValue=""
                    />
                  </FormControl>

                  <Divider />
                  <hr/>
                  <Button variant="contained" color="primary" type='submit' fullWidth={false} endIcon={<Icon>send</Icon>} className={classes.sendButton}>Испрати</Button>
              </Grid>
            </form>
            </CardContent>
        </Card>
      )
}

export default ContactPage;
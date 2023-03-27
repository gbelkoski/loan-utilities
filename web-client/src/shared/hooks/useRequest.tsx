import React, { useState, useContext } from 'react';
import { Response, RequestProps, RequestResponseProps } from '../interfaces/HttpClientInterface';
import ErrorDialog from '../dialogs/errorDialog';
import { DialogContext } from '../../context/dialogContext';


export default function useRequest<T>(
   { api, method, config = null }: RequestProps ): RequestResponseProps<T> 
{
      const [error, setError] = useState<string>('');
      const [isLoading, setIsLoading] = useState<boolean>(false);
      const { setDialog } = useContext(DialogContext);

      const request = async (url: string, data?: string | undefined | object): Promise<T> => {

         setError("Some dumb error");
         if(method === 'get' && typeof data === 'string') {
            data = {...config, params: JSON.parse(data)};
         }

         try {
            setIsLoading(true);
            
            return await api[method](url, data, config)
               .then((res: Response<T>) => {
                  return (res.data as T);
               })
               .finally(() => {
                  setIsLoading(false);
               });
         } 
         catch (err) {
            if (err.response) {
               // The request was made and the server responded with a status code
               // that falls out of the range of 2xx

               const reducer = (accumulator: string, currentValue: unknown, index: number ): 
                     string => { return `${accumulator} ${index + 1}. ${currentValue}`};
                     
               if(err.response.data.code === 'validation_error'){
                  const errorValues = Object.values(err.response.data.reason).reduce<string>(reducer, ''); 
                  setDialog(<ErrorDialog title="validation errors" message={errorValues} />)
               }
               else {
                  // setDialog(<ErrorDialog 
                  //    title={err.response.data.code || err.response.status} 
                  //    message={`${err.response.data.reason || err.response.data.title} - error from ${err.response.data.api } api`} />
                  // )
                  alert("Настана грешка при испраќање на пораката.")
               }
            }
            else {
               //setDialog(<ErrorDialog title={err.response.status} message={`error from ${err.response.data.api} api`} />)
               alert("Настана грешка при испраќање на пораката.")
            }
               //maybe useful in future console.log(err.response.status); console.log(err.response.headers)
            //Send error message to cient 
            //setError(err.message);
            console.log('we got here');
            setError("Some error happned");
         }

         return { } as T;
      };

   return { request, error, isLoading };
}
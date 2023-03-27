import React from 'react';
import { makeStyles, Theme, Button, ButtonProps } from '@material-ui/core';
import { FormattedMessage } from 'react-intl';

interface Props extends ButtonProps {
  component?: React.ReactNode;
  defaultMessage?: string;
  id?: string;
  children?: React.ReactNode;
  styleType?: 'submit' | 'cancel';
  onClick?: (event: React.MouseEvent<HTMLElement>) => void;
  to?: string;
}

type StylesProps = {
  styleType?: 'submit' | 'cancel';
}

const useStyles = makeStyles((theme: Theme) => ({
  button: {
    // backgroundColor: ({ styleType }: StylesProps): string => {
    //   switch (styleType) {
    //     case 'submit':
    //       return 
    //     case 'cancel':
    //       return theme.palette.common.white;
    //     default:
    //       return theme.palette.tertiary.main;
    //   }
    // },
    // color: ({ styleType }: StylesProps): string => {
    //   switch (styleType) {
    //     case 'submit':
    //       return theme.palette.common.white;
    //     case 'cancel':
    //       return theme.palette.buttonMain.main;
    //     default:
    //       return theme.palette.common.white;
    //   }
    // },
    fontSize: 13,
    fontWeight: ({ styleType }: StylesProps): number => styleType === 'cancel' ? 600 : 400,
    height: 25,
    padding: '0 20px 1px 20px',
    '&:hover': {
      opacity: 0.5,
    //   backgroundColor: ({ styleType }: StylesProps): string => {
    //     switch (styleType) {
    //       case 'submit':
    //         return theme.palette.buttonMain.main;
    //       case 'cancel':
    //         return theme.palette.common.white;
    //       default:
    //         return theme.palette.tertiary.main;
    //     }
    //   },
    },
    textTransform: 'none'
  },
  disabled: {
    // color: ({ styleType }: StylesProps): string => {
    //   switch (styleType) {
    //     case 'submit':
    //       return `${theme.palette.common.white} !important`;
    //     case 'cancel':
    //       return `${theme.palette.buttonMain.main} !important`;
    //     default:
    //       return `${theme.palette.common.white} !important`;
    //   }
    // },
    opacity: 0.25,
  }
}));

const StyledButton = ({ defaultMessage, id, children, styleType, ...props }: Props): JSX.Element => {
  const classes = useStyles({ styleType });

  return (
    <Button classes={{
      root: classes.button,
      disabled: classes.disabled
    }} {...props}>
      {children ? children
       : (defaultMessage && id) ? (
          <FormattedMessage
            defaultMessage={defaultMessage}
            id={id}
          />
       ) : null
      }
    </Button>
  )
}

export default StyledButton;

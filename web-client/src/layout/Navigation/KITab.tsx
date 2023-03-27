import React from 'react';
import Tab from '@material-ui/core/Tab';
import { makeStyles } from '@material-ui/core/styles';

interface StyledTabProps {
  disabled?: boolean;
  label?: string;
  name?: string;
  value: string;
}

const useStyles = makeStyles({
    root: {
      color: '#183248',
      lineHeight: 1.35,
      flex: '1 0 auto',
      minWidth: 72,
      opacity: 1,
      overflow: 'visible',
      padding: 0.5,
      '& [class]': {
        fill: 'currentColor',
      },
      '&:focus&::after, &:hover&::after, &[aria-selected="true"]&::after': {
        borderColor: '#000000',
        borderStyle: 'solid',
        borderWidth: 1,
        bottom: '0',
        content: '\'\'',
        display: 'block',
        position: 'absolute',
        width: '100%',
      },
    },
    selected: {
      color: '#AAAAAA',
    },
  });
const KITab = ({ ...props }: StyledTabProps): JSX.Element => {
  const classes = useStyles();

  return <Tab classes={{
      root: classes.root,
      selected: classes.selected
    }}
    disableRipple {...props}
  />
}

export default KITab;

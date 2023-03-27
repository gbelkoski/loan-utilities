import Tabs from '@material-ui/core/Tabs';
import { withStyles } from '@material-ui/core/styles';
import { constants } from '../../themes/globalStyles';

const KITabs = withStyles(({ breakpoints }) => ({
  root: {
    overflow: 'visible',
  },
  indicator: {
    display:'none',
  },
  fixed: {
    overflow: 'visible !important',
  },
  flexContainer: {
    justifyContent: 'space-around',
    maxWidth: constants.navMaxWidth,
    margin: 'auto',
    padding: '0 12px',
    [breakpoints.down('md')]: {
      padding: '0 4px',
    },
  }
}))(Tabs);

export default KITabs;
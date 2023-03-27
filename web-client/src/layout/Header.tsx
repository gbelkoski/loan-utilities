import React from "react";
import { makeStyles, useTheme } from '@material-ui/core/styles';
import clsx from 'clsx';
import useMediaQuery from '@material-ui/core/useMediaQuery';
import { Toolbar, AppBar, IconButton, ListItemText, ListItem, List, SwipeableDrawer } from '@material-ui/core';
import MenuIcon from '@material-ui/icons/Menu';
import NavigationMenu from "./Navigation/NavigationMenu";
import { navItems } from './Navigation/NavigationMenu';

const useStyles = makeStyles({
    root: {   
        flexGrow: 1,
    },
    header: {
        background: '#F8F9FA',
        left: 'auto',
        right: 'auto',
        paddingLeft: 2.5,
        paddingRight: 2.5,
        justifyContent: 'flex-end',
        marginBottom: 1,
    },
    desktopNavigation: {
        display: 'flex',
        flex: '2 1 0px',
        justifyContent: 'center',
        textAlign: 'center',
    },
    list: {
        width: 250,
    },
    fullList: {
        width: 'auto',
    },
    menuButton: {
        color: "gray",
        paddingLeft: 20
    }
});

type Anchor = 'top';

const Header: React.FC = () => {
    const classes = useStyles();
    const theme = useTheme();
    const matchesDesktop = useMediaQuery(theme.breakpoints.up('md'))
    const [state, setState] = React.useState({
        top: false
      });

    const listItemClick = () => {
        console.log('Hi');
    }
    
    const toggleDrawer = (anchor: Anchor, open: boolean) => (
        event: React.KeyboardEvent | React.MouseEvent,
      ) => {
        if (
          event &&
          event.type === 'keydown' &&
          ((event as React.KeyboardEvent).key === 'Tab' ||
            (event as React.KeyboardEvent).key === 'Shift')
        ) {
          return;
        }
    
        setState({ ...state, [anchor]: open });
      };

    const list = (anchor: Anchor) => (
        <div
            className={clsx(classes.list, {
            [classes.fullList]: anchor === 'top',
            })}
            role="presentation"
            onClick={toggleDrawer(anchor, false)}
            onKeyDown={toggleDrawer(anchor, false)}
        >
            <List>
            {navItems.map((tab) => (
                <ListItem button key={tab.route} onClick={listItemClick}>
                    <ListItemText primary={tab.label} />
                </ListItem>
            ))}
            </List>
        </div>
    );

    return (
        <div className={classes.root}>
            <AppBar
                className={classes.header}
                position="fixed"
            >
                <Toolbar variant="dense" disableGutters>
                    
                {!matchesDesktop && (
                    <IconButton
                    className={classes.menuButton}
                    aria-label="open drawer"
                    onClick={toggleDrawer('top', true)}
                    edge="start"
                  >
                    <MenuIcon />
                  </IconButton>
                )}
                {matchesDesktop && (
                    <div className={classes.desktopNavigation}>
                    <NavigationMenu />
                    </div>
                )}
                </Toolbar>
            </AppBar>
            {(['top'] as Anchor[]).map((anchor) => (
                <React.Fragment key={anchor}>
                <SwipeableDrawer
                    anchor={anchor}
                    open={state[anchor]}
                    onClose={toggleDrawer(anchor, false)}
                    onOpen={toggleDrawer(anchor, true)}
                >
                    {list(anchor)}
                </SwipeableDrawer>
                </React.Fragment>
            ))}
        </div>
      );
}

export default Header;
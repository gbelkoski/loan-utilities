import React, { useEffect, useState } from 'react';
import { RouteComponentProps, withRouter, useLocation } from 'react-router-dom';
import { makeStyles } from '@material-ui/core/styles';
import KITabs from './KITabs'
import KITab from './KITab'

interface NavigationItem {
    isDisabled: boolean;
    name: string;
    label: string;
    route: string;
}

type NavItems = NavigationItem[];

export const navItems: NavItems = [
    {
      isDisabled: false,
      name: 'Landing',
      label: 'Почетна',
      route: '/',
    },
    {
      isDisabled: false,
      name: 'Loans',
      label: 'Кредити',
      route: 'loans',
    },
    {
      isDisabled: false,
      name: 'FAQ',
      label: 'ЧПП',
      route: 'faq',
    },
    {
      isDisabled: false,
      name: 'Contact',
      label: 'Контакт',
      route: 'contact',
    },
    {
      isDisabled: false,
      name: 'About Us',
      label: 'За нас',
      route: 'about',
    }
  ]

const useStyles = makeStyles(() => ({
  root: {
    flexGrow: 1
  },
  icon: {
    width: 'initial',
    height: 'initial'
  }
}));

function NavigationTabBar({ history }: RouteComponentProps): JSX.Element { 
  const classes = useStyles();
  const location = useLocation();
  const [ selectedTab, setSelectedTab ] = useState<string | boolean>(false);

  const findSelectedTab = (): string | boolean => {
    const selectedTab = navItems.find(item => history.location.pathname.includes(item.route));
    return selectedTab?.route || false;
  }

  useEffect(() => setSelectedTab(findSelectedTab()), [location]);


  const handleCallToRouter = (event: React.ChangeEvent<{}>, value: string): void => {
    history.push(value);
  }

  return (
    <div className={classes.root}>
      <KITabs
        value={selectedTab}
        onChange={handleCallToRouter}
        centered
        scrollButtons="auto"
        aria-label="Main"
        role="navigation"
      >
        {navItems.map((tab): JSX.Element | null=> {
          if (tab.name) {
            return (
              <KITab
                key={tab.name}
                value={tab.route}
                disabled={tab.isDisabled}
                name={tab.name}
                label={tab.label}
              />
            )
          }

          return null;
        })}
      </KITabs>
    </div>
  );
}

export default withRouter(NavigationTabBar);
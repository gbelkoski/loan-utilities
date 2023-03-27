import React, { lazy, Suspense } from 'react';
import MainLoader from '../shared/components/mainLoader';
import { Route } from 'react-router-dom';
import ContactPage from '../publicViews/contactPage'

const LandingPage = lazy(() => import('../publicViews/landingPage'));
const LoansPage = lazy(() => import('../publicViews/loansPage'));
const FAQPage = lazy(() => import('../publicViews/faqPage'));
const AboutPage = lazy(() => import('../publicViews/aboutPage'));


export enum RoutesConfig {
  LoansPage = '/loans',
  FAQPage = '/faq',
  ContactPage = '/contact',
  AboutPage = '/about'
}

export const PublicRoutes = (
  <>
    <Route
      exact={true}
      path={RoutesConfig.LoansPage}
    >
      <Suspense fallback={<MainLoader />}>
        <LoansPage />
      </Suspense>
    </Route>
    <Route
      exact={true}
      path={RoutesConfig.FAQPage}
    >
      <Suspense fallback={<MainLoader />}>
        <FAQPage />
      </Suspense>
    </Route>
    <Route
      exact={true}
      path={RoutesConfig.ContactPage}
    >
      <Suspense fallback={<MainLoader />}>
        <ContactPage />
      </Suspense>
    </Route>
    <Route
      exact={true}
      path={RoutesConfig.AboutPage}
    >
      <Suspense fallback={<MainLoader />}>
        <AboutPage />
      </Suspense>
    </Route>
    <Route  
      exact
      path="/">
      <Suspense fallback={<MainLoader />}>
        <LandingPage />
      </Suspense>
    </Route>
    {/* <Route path="*">
      <Suspense fallback={<MainLoader />}>
        <NotFoundPage />
      </Suspense>
    </Route> */}
  </>
);

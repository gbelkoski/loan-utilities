/* eslint-disable @typescript-eslint/interface-name-prefix */


declare module '@material-ui/core/styles/createPalette' {
  interface Palette {
    accent: Palette['primary'];
    active: Palette['primary'];
    highlight: Palette['primary'];
    paper: Palette['primary'];
    header: Palette['primary'];
    headerButtonsBg: Palette['primary'];
    reversedPaper: Palette['primary'];
    reversedText: Palette['primary'];
    mainContainerBg: Palette['primary'];
    avatarBg: Palette['primary'];
    avatarText: Palette['primary'];
    checkCircleIcon: Palette['primary'];
    helpIcon: Palette['primary'];
    surveyIcon: Palette['primary'];
  }

  interface PaletteOptions {
    accent: PaletteOptions['primary'];
    active: PaletteOptions['primary'];
    highlight: PaletteOptions['primary'];
    paper: PaletteOptions['primary'];
    header: PaletteOptions['primary'];
    headerButtonsBg: PaletteOptions['primary'];
    reversedPaper: PaletteOptions['primary'];
    reversedText: PaletteOptions['primary'];
    mainContainerBg: PaletteOptions['primary'];
    avatarBg: PaletteOptions['primary'];
    avatarText: PaletteOptions['primary'];
    checkCircleIcon: PaletteOptions['primary'];
    helpIcon: PaletteOptions['primary'];
    surveyIcon: PaletteOptions['primary'];
  }
}

export const globalStyles = {
  breakpoints: {
    values: {
      xs: 0,
      sm: 600,
      md: 1040,
      lg: 1280,
      xl: 1640,
    },
  },
  palette: {
    sideBg:'#EDEDED',
    lightBg:'#FFFFFF',
    active: {
      main: '#48A2D9'
    },
    warning: {
      main: '#F19511'
    },
    error: {
      main: '#DC5656'
    },
    info: {
      main: '#5476D8'
    },
    success: {
      main: '#7AE046'
    },
    gray: {
      800: '#333'
    }
  },
  shape: {
    borderRadius: 6
  },
  typography: {
    fontFamily: 'Inter, Arial',
    h1: {
      fontSize: 24,
      fontWeight: 600,
      letterSpacing: '-0.5px'
    },
    h2: {
      fontSize: '16pt',
      fontWeight: 600,
      letterSpacing: '-0.5px'
    },
    h3: {
      fontSize: '12pt',
      fontWeight: 600,
      letterSpacing: '-0.5px'
    },
    h4: {
      fontSize: '10pt',
      letterSpacing: '-0.5px'
    },
    h5: {
      fontSize: '10pt',
      letterSpacing: '-0.5px'
    },
    h6: {
      fontSize: '10pt',
      fontWeight: 500,
      letterSpacing: '-0.5px'
    },
    caption: {
      fontSize: '11pt',
      letterSpacing: '-0.5px'
    }
  },
  overrides: {
    MuiBackdrop: {
      root: {
        backgroundColor: 'transparent'
      }
    },
  }
};

export const constants = {
  navMaxWidth: 730
}

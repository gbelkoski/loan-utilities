// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
    production: false,
    domains: {
        api: 'api/',
        // baseurl: 'http://vmi282223.contaboserver.net/'
        baseurl: 'http://localhost:5000/',
        // baseurl: 'http://ec2-3-121-161-148.eu-central-1.compute.amazonaws.com/'
    }
};

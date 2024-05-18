tailwind.config = {
    content: ["**/*.razor", "**/*.cshtml", "**/*.html"],
    theme: {
        container: {
            center: true,
        },
        screens: {
            'sm': '640px',
            'md': '768px',
            'lg': '1024px',
            'xl': '1280px',
            '2xl': '1536px',
            '3xl': '1792px',
        },
        fontFamily: {
            sans: ['Graphik', 'sans-serif'],
            serif: ['Merriweather', 'serif'],
        },
        fontSize: {
            md: ['1.0625rem', '1.25rem']
        },
        variants: {
            backgroundColor: ['even', 'odd', 'hover']
        },
        extend: {
            colors: {
                'text': {
                    DEFAULT: '#e8f7fc',
                    50: '#e8f7fc',
                    100: '#d2eff9',
                    200: '#a5e0f3',
                    300: '#78d0ed',
                    400: '#4ac0e8',
                    500: '#1db1e2',
                    600: '#178db5',
                    700: '#126a87',
                    800: '#0c475a',
                    900: '#06232d',
                    950: '#031217',
                },
                'white': {
                    DEFAULT: '#e9f0f2',
                    50: '#eff4f6',
                    100: '#dfe9ec',
                    200: '#bfd4d9',
                    300: '#9fbec6',
                    400: '#7ea8b4',
                    500: '#5e92a1',
                    600: '#4b7581',
                    700: '#395860',
                    800: '#263b40',
                    900: '#131d20',
                    950: '#090f10',
                },
                'light': {
                    DEFAULT: '#cfe2e9',
                    50: '#eef4f7',
                    100: '#dceaef',
                    200: '#b9d5df',
                    300: '#96c0cf',
                    400: '#73abbf',
                    500: '#5096af',
                    600: '#40788c',
                    700: '#305a69',
                    800: '#203c46',
                    900: '#101e23',
                    950: '#080f11',
                },
                'dark': {
                    DEFAULT: '#151e21',
                    50: '#eff4f5',
                    100: '#e0e8eb',
                    200: '#c1d2d7',
                    300: '#a2bbc3',
                    400: '#83a4af',
                    500: '#638e9c',
                    600: '#50717c',
                    700: '#3c555d',
                    800: '#28393e',
                    900: '#141c1f',
                    950: '#0a0e10',
                },
                'background': {
                    DEFAULT: '#0a1215',
                    50: '#eef4f7',
                    100: '#ddeaee',
                    200: '#bad4de',
                    300: '#98bfcd',
                    400: '#75aabd',
                    500: '#5394ac',
                    600: '#42778a',
                    700: '#325967',
                    800: '#213b45',
                    900: '#111e22',
                    950: '#080f11',
                },
                'body': {
                    DEFAULT: '#0a1215',
                    50: '#eef4f7',
                    100: '#ddeaee',
                    200: '#bad4de',
                    300: '#98bfcd',
                    400: '#75aabd',
                    500: '#5394ac',
                    600: '#42778a',
                    700: '#325967',
                    800: '#213b45',
                    900: '#111e22',
                    950: '#080f11',
                },
                'primary': {
                    DEFAULT: '#21a6c4',
                    50: '#e9f8fb',
                    100: '#d3f1f8',
                    200: '#a8e3f0',
                    300: '#7cd5e9',
                    400: '#51c7e1',
                    500: '#25b9da',
                    600: '#1e94ae',
                    700: '#166f83',
                    800: '#0f4a57',
                    900: '#07252c',
                    950: '#041216',
                },
                'secondary': {
                    DEFAULT: '#7a3733',
                    50: '#f7eeed',
                    100: '#f0dcdb',
                    200: '#e1b9b7',
                    300: '#d29693',
                    400: '#c3736f',
                    500: '#b4504b',
                    600: '#90403c',
                    700: '#6c302d',
                    800: '#48201e',
                    900: '#24100f',
                    950: '#120808',
                },
                'accent': {
                    DEFAULT: '#bbb85d',
                    50: '#f7f7ed',
                    100: '#f0efdb',
                    200: '#e1e0b7',
                    300: '#d2d093',
                    400: '#c3c06f',
                    500: '#b4b04b',
                    600: '#908d3c',
                    700: '#6c6a2d',
                    800: '#48471e',
                    900: '#24230f',
                    950: '#121208',
                },
                success: {
                    DEFAULT: '#0E9F6E',
                    50: '#F3FAF7',
                    100: '#DEF7EC',
                    200: '#BCF0DA',
                    300: '#84E1BC',
                    400: '#31C48D',
                    500: '#0E9F6E',
                    600: '#057A55',
                    700: '#046C4E',
                    800: '#03543F',
                    900: '#014737'
                },
                danger: {
                    DEFAULT: '#F05252',
                    50: '#FDF2F2',
                    100: '#FDE8E8',
                    200: '#FBD5D5',
                    300: '#F8B4B4',
                    400: '#F98080',
                    500: '#F05252',
                    600: '#E02424',
                    700: '#C81E1E',
                    800: '#9B1C1C',
                    900: '#771D1D'
                },
                warning: {
                    DEFAULT: '#C27803',
                    50: '#FDFDEA',
                    100: '#FDF6B2',
                    200: '#FCE96A',
                    300: '#FACA15',
                    400: '#E3A008',
                    500: '#C27803',
                    600: '#9F580A',
                    700: '#8E4B10',
                    800: '#723B13',
                    900: '#633112'
                },
                info: {
                    DEFAULT: '#03A9F4',
                    50: '#E1F5FE',
                    100: '#B3E5FC',
                    200: '#81D4FA',
                    300: '#4FC3F7',
                    400: '#29B6F6',
                    500: '#03A9F4',
                    600: '#039BE5',
                    700: '#0288D1',
                    800: '#0277BD',
                    900: '#01579B'
                }
            },
            spacing: {
                '128': '32rem',
                '144': '36rem',
            },
            borderWidth: {
                DEFAULT: '1px',
                '0': '0',
                '1': '1px',
                '2': '2px',
                '3': '3px',
                '4': '4px',
                '5': '5px',
                '6': '6px',
                '7': '7px',
                '8': '8px'
            },
            borderRadius: {
                '4xl': '2rem',
            },
            flexGrow: {
                '0': 0,
                '1': 1
            }
        }
    },
    plugins: [
        ({ addVariant }) => {
            // based on: https://github.com/tailwindlabs/tailwindcss/blob/f116f9f6648af81bf22e0c28d01a8da015a53180/src/corePlugins.js#L61-L129
            [
                // Positional
                ['first', ':first-child'],
                ['last', ':last-child'],
                ['only', ':only-child'],
                ['odd', ':nth-child(odd)'],
                ['even', ':nth-child(even)'],
                'first-of-type',
                'last-of-type',
                'only-of-type',

                // State
                'visited',
                'target',
                ['open', '[open]'],

                // Forms
                'default',
                'checked',
                'indeterminate',
                'placeholder-shown',
                'autofill',
                'required',
                'valid',
                'invalid',
                'in-range',
                'out-of-range',
                'read-only',

                // Content
                'empty',

                // Interactive
                'focus-within',
                'hover',
                'focus',
                'focus-visible',
                'active',
                'disabled',
            ]
                .map((variant) =>
                    Array.isArray(variant) ? variant : [variant, `:${variant}`]
                )
                .forEach(([variantName, state]) => {
                    addVariant(`parent-${variantName}`, `:merge(.parent)${state} > &`);
                });
        },
        function ({ addBase, theme }) {
            function extractColorVars(colorObj, colorGroup = '') {
                return Object.keys(colorObj).reduce((vars, colorKey) => {
                    const value = colorObj[colorKey];
                    const cssVariable = colorKey === "DEFAULT" ? `--btw-color${colorGroup}` : `--btw-color${colorGroup}-${colorKey}`;

                    const newVars =
                        typeof value === 'string'
                            ? { [cssVariable]: value }
                            : extractColorVars(value, `-${colorKey}`);

                    return { ...vars, ...newVars };
                }, {});
            }

            addBase({
                ':root': extractColorVars(theme('colors')),
            });
        }
    ]
}
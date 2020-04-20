function SvgReplaceWith(svgStr, iconClass) {
    let svg = $(svgStr).addClass($('.' + iconClass).attr('class'));
    $(".myicon." + iconClass).replaceWith(svg);
}

let svgLogo = "<svg id='svgtest' version='1.1' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink'  viewBox='0, 0, 400,364.4444444444444'><g id='svgg'><path id='path0' d='M185.185 2.619 C 107.021 13.564,52.349 67.512,43.712 142.222 C 42.256 154.813,41.942 155.451,35.617 158.698 C 17.372 168.063,6.890 180.111,3.225 195.926 C 1.150 204.881,1.159 261.108,3.237 270.000 C 11.172 303.957,62.324 326.021,75.364 301.111 C 78.771 294.603,78.726 295.541,79.298 218.519 C 79.618 175.461,80.150 143.582,80.597 140.741 C 87.492 96.819,119.219 59.356,161.481 45.232 C 228.908 22.699,299.937 61.896,317.414 131.282 C 320.141 142.109,320.725 158.852,320.739 226.667 C 320.752 288.129,320.949 292.827,323.786 299.255 C 335.790 326.460,389.363 304.915,396.669 269.944 C 398.494 261.206,398.495 204.635,396.670 195.926 C 393.425 180.443,382.673 168.055,364.358 158.698 C 357.949 155.424,357.600 154.740,356.310 142.963 C 348.787 74.271,298.519 19.071,231.111 5.484 C 211.022 1.434,199.003 0.685,185.185 2.619 M194.979 111.459 C 187.993 113.641,183.748 119.456,182.255 128.889 C 180.966 137.034,181.242 339.859,182.550 346.033 C 187.270 368.299,212.252 369.175,217.116 347.244 C 218.627 340.433,218.653 132.048,217.144 125.926 C 214.285 114.329,205.064 108.310,194.979 111.459 M148.063 147.643 C 141.755 150.004,138.112 154.479,136.194 162.222 C 134.484 169.129,134.729 307.047,136.462 312.640 C 142.485 332.080,165.957 331.275,170.228 311.481 C 173.479 296.410,173.035 170.109,169.692 159.172 C 166.833 149.816,156.696 144.413,148.063 147.643 M241.111 147.409 C 237.957 148.397,233.528 152.267,231.918 155.442 C 228.850 161.493,228.790 163.224,229.029 239.259 L 229.259 312.222 231.014 316.105 C 238.101 331.780,258.274 329.631,263.538 312.640 C 265.254 307.101,265.519 168.292,263.826 161.713 C 261.016 150.791,250.816 144.368,241.111 147.409 M99.301 195.002 C 90.658 199.572,89.647 203.934,89.647 236.667 C 89.647 264.281,89.979 267.536,93.353 272.994 C 100.077 283.875,117.635 281.851,122.911 269.586 C 127.156 259.718,127.187 213.453,122.955 203.882 C 118.790 194.463,107.988 190.408,99.301 195.002 M285.556 194.738 C 276.170 199.083,274.107 206.697,274.093 237.037 C 274.084 256.249,274.828 264.331,277.089 269.586 C 283.819 285.232,304.869 283.192,309.322 266.463 C 310.836 260.777,310.802 212.428,309.280 206.710 C 306.331 195.627,295.471 190.147,285.556 194.738 ' stroke='none' fill='#000000' fill-rule='evenodd'></path></g></svg>";

let svgRepeat = "<svg aria-hidden='true' focusable='false' data-prefix='fas' data-icon='repeat-alt' role='img' xmlns='http://www.w3.org/2000/svg' viewBox='0 0 512 512' class='svg-inline--fa fa-repeat-alt fa-w-16'><path fill='currentColor' d='M493.544 181.463c11.956 22.605 18.655 48.4 18.452 75.75C511.339 345.365 438.56 416 350.404 416H192v47.495c0 22.475-26.177 32.268-40.971 17.475l-80-80c-9.372-9.373-9.372-24.569 0-33.941l80-80C166.138 271.92 192 282.686 192 304v48h158.875c52.812 0 96.575-42.182 97.12-94.992.155-15.045-3.17-29.312-9.218-42.046-4.362-9.185-2.421-20.124 4.8-27.284 4.745-4.706 8.641-8.555 11.876-11.786 11.368-11.352 30.579-8.631 38.091 5.571zM64.005 254.992c.545-52.81 44.308-94.992 97.12-94.992H320v47.505c0 22.374 26.121 32.312 40.971 17.465l80-80c9.372-9.373 9.372-24.569 0-33.941l-80-80C346.014 16.077 320 26.256 320 48.545V96H161.596C73.44 96 .661 166.635.005 254.788c-.204 27.35 6.495 53.145 18.452 75.75 7.512 14.202 26.723 16.923 38.091 5.57 3.235-3.231 7.13-7.08 11.876-11.786 7.22-7.16 9.162-18.098 4.8-27.284-6.049-12.735-9.374-27.001-9.219-42.046z' class=''></path></svg>";

let svgRepeat1 = "<svg aria-hidden='true' focusable='false' data-prefix='fas' data-icon='repeat-1-alt' role='img' xmlns='http://www.w3.org/2000/svg' viewBox='0 0 512 512' class='svg-inline--fa fa-repeat-1-alt fa-w-16'><path fill='currentColor' d='M493.544 181.463c11.956 22.605 18.655 48.4 18.452 75.75C511.339 345.365 438.56 416 350.404 416H192v47.495c0 22.475-26.177 32.268-40.971 17.475l-80-80c-9.372-9.373-9.372-24.569 0-33.941l80-80C166.138 271.92 192 282.686 192 304v48h158.875c52.812 0 96.575-42.182 97.12-94.992.155-15.045-3.17-29.312-9.218-42.046-4.362-9.185-2.421-20.124 4.8-27.284 4.745-4.706 8.641-8.555 11.876-11.786 11.368-11.352 30.579-8.631 38.091 5.571zM64.005 254.992c.545-52.81 44.308-94.992 97.12-94.992H320v47.505c0 22.374 26.121 32.312 40.971 17.465l80-80c9.372-9.373 9.372-24.569 0-33.941l-80-80C346.014 16.077 320 26.256 320 48.545V96H161.596C73.44 96 .661 166.635.005 254.788c-.204 27.35 6.495 53.145 18.452 75.75 7.512 14.202 26.723 16.923 38.091 5.57 3.235-3.231 7.13-7.08 11.876-11.786 7.22-7.16 9.162-18.098 4.8-27.284-6.049-12.735-9.374-27.001-9.219-42.046zm163.258 44.535c0-7.477 3.917-11.572 11.573-11.572h15.131v-39.878c0-5.163.534-10.503.534-10.503h-.356s-1.779 2.67-2.848 3.738c-4.451 4.273-10.504 4.451-15.666-1.068l-5.518-6.231c-5.342-5.341-4.984-11.216.534-16.379l21.72-19.939c4.449-4.095 8.366-5.697 14.42-5.697h12.105c7.656 0 11.749 3.916 11.749 11.572v84.384h15.488c7.655 0 11.572 4.094 11.572 11.572v8.901c0 7.477-3.917 11.572-11.572 11.572h-67.293c-7.656 0-11.573-4.095-11.573-11.572v-8.9z' class=''></path></svg>";

let svgListMusic = "<svg aria-hidden='true' focusable='false' data-prefix='fas' data-icon='list-music' role='img' xmlns='http://www.w3.org/2000/svg' viewBox='0 0 512 512' class='svg-inline--fa fa-list-music fa-w-16'><path fill='currentColor' d='M16 256h256a16 16 0 0 0 16-16v-32a16 16 0 0 0-16-16H16a16 16 0 0 0-16 16v32a16 16 0 0 0 16 16zm0-128h256a16 16 0 0 0 16-16V80a16 16 0 0 0-16-16H16A16 16 0 0 0 0 80v32a16 16 0 0 0 16 16zm128 192H16a16 16 0 0 0-16 16v32a16 16 0 0 0 16 16h128a16 16 0 0 0 16-16v-32a16 16 0 0 0-16-16zM470.94 1.33l-96.53 28.51A32 32 0 0 0 352 60.34V360a148.76 148.76 0 0 0-48-8c-61.86 0-112 35.82-112 80s50.14 80 112 80 112-35.82 112-80V148.15l73-21.39a32 32 0 0 0 23-30.71V32a32 32 0 0 0-41.06-30.67z' class=''></path></svg>";

let svgVolume = "<svg aria-hidden='true' focusable='false' data-prefix='fas' data-icon='volume' role='img' xmlns='http://www.w3.org/2000/svg' viewBox='0 0 480 512' class='svg-inline--fa fa-volume fa-w-15'><path fill='currentColor' d='M215.03 71.05L126.06 160H24c-13.26 0-24 10.74-24 24v144c0 13.25 10.74 24 24 24h102.06l88.97 88.95c15.03 15.03 40.97 4.47 40.97-16.97V88.02c0-21.46-25.96-31.98-40.97-16.97zM480 256c0-63.53-32.06-121.94-85.77-156.24-11.19-7.14-26.03-3.82-33.12 7.46s-3.78 26.21 7.41 33.36C408.27 165.97 432 209.11 432 256s-23.73 90.03-63.48 115.42c-11.19 7.14-14.5 22.07-7.41 33.36 6.51 10.36 21.12 15.14 33.12 7.46C447.94 377.94 480 319.53 480 256zm-141.77-76.87c-11.58-6.33-26.19-2.16-32.61 9.45-6.39 11.61-2.16 26.2 9.45 32.61C327.98 228.28 336 241.63 336 256c0 14.38-8.02 27.72-20.92 34.81-11.61 6.41-15.84 21-9.45 32.61 6.43 11.66 21.05 15.8 32.61 9.45 28.23-15.55 45.77-45 45.77-76.88s-17.54-61.32-45.78-76.86z' class=''></path></svg>";

let svgVolumeMute = "<svg aria-hidden='true' focusable='false' data-prefix='fas' data-icon='volume-mute' role='img' xmlns='http://www.w3.org/2000/svg' viewBox='0 0 512 512' class='svg-inline--fa fa-volume-mute fa-w-16'><path fill='currentColor' d='M215.03 71.05L126.06 160H24c-13.26 0-24 10.74-24 24v144c0 13.25 10.74 24 24 24h102.06l88.97 88.95c15.03 15.03 40.97 4.47 40.97-16.97V88.02c0-21.46-25.96-31.98-40.97-16.97zM461.64 256l45.64-45.64c6.3-6.3 6.3-16.52 0-22.82l-22.82-22.82c-6.3-6.3-16.52-6.3-22.82 0L416 210.36l-45.64-45.64c-6.3-6.3-16.52-6.3-22.82 0l-22.82 22.82c-6.3 6.3-6.3 16.52 0 22.82L370.36 256l-45.63 45.63c-6.3 6.3-6.3 16.52 0 22.82l22.82 22.82c6.3 6.3 16.52 6.3 22.82 0L416 301.64l45.64 45.64c6.3 6.3 16.52 6.3 22.82 0l22.82-22.82c6.3-6.3 6.3-16.52 0-22.82L461.64 256z' class=''></path></svg>";

$(() => {
    SvgReplaceWith(svgLogo, 'icon-logo');
    SvgReplaceWith(svgRepeat, 'fa-repeat');
    SvgReplaceWith(svgRepeat1, 'fa-repeat-1');
    SvgReplaceWith(svgListMusic, 'fa-list-music');
    SvgReplaceWith(svgVolume, 'fa-volume');
    SvgReplaceWith(svgVolumeMute, 'fa-volume-mute');
});

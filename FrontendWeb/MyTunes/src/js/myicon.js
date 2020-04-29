import JQuery from 'jquery'
let $ = JQuery;

let tabSvg = [
    {
        'nom' : 'heart',
        'svg' : '<svg class="svg-inline--fa fa-heart fa-w-16 control-icon" aria-hidden="true" data-prefix="fas" data-icon="heart" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" data-fa-i2svg=""><path fill="currentColor" d="M462.3 62.6C407.5 15.9 326 24.3 275.7 76.2L256 96.5l-19.7-20.3C186.1 24.3 104.5 15.9 49.7 62.6c-62.8 53.6-66.1 149.8-9.9 207.9l193.5 199.8c12.5 12.9 32.8 12.9 45.3 0l193.5-199.8c56.3-58.1 53-154.3-9.8-207.9z"/></svg>'
    }, {
        'nom' : 'list-music',
        'svg' : '<svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="list-music" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" class="svg-inline--fa fa-list-music fa-w-16 control-icon myicon"><path fill="currentColor" d="M16 256h256a16 16 0 0 0 16-16v-32a16 16 0 0 0-16-16H16a16 16 0 0 0-16 16v32a16 16 0 0 0 16 16zm0-128h256a16 16 0 0 0 16-16V80a16 16 0 0 0-16-16H16A16 16 0 0 0 0 80v32a16 16 0 0 0 16 16zm128 192H16a16 16 0 0 0-16 16v32a16 16 0 0 0 16 16h128a16 16 0 0 0 16-16v-32a16 16 0 0 0-16-16zM470.94 1.33l-96.53 28.51A32 32 0 0 0 352 60.34V360a148.76 148.76 0 0 0-48-8c-61.86 0-112 35.82-112 80s50.14 80 112 80 112-35.82 112-80V148.15l73-21.39a32 32 0 0 0 23-30.71V32a32 32 0 0 0-41.06-30.67z" class=""/></svg>'
    }, {
        'nom' : 'logo',
        'svg' : '<svg id="svgtest" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0, 0, 400,364.4444444444444" class="myicon icon-logo"><g id="svgg"><path id="path0" d="M185.185 2.619 C 107.021 13.564,52.349 67.512,43.712 142.222 C 42.256 154.813,41.942 155.451,35.617 158.698 C 17.372 168.063,6.890 180.111,3.225 195.926 C 1.150 204.881,1.159 261.108,3.237 270.000 C 11.172 303.957,62.324 326.021,75.364 301.111 C 78.771 294.603,78.726 295.541,79.298 218.519 C 79.618 175.461,80.150 143.582,80.597 140.741 C 87.492 96.819,119.219 59.356,161.481 45.232 C 228.908 22.699,299.937 61.896,317.414 131.282 C 320.141 142.109,320.725 158.852,320.739 226.667 C 320.752 288.129,320.949 292.827,323.786 299.255 C 335.790 326.460,389.363 304.915,396.669 269.944 C 398.494 261.206,398.495 204.635,396.670 195.926 C 393.425 180.443,382.673 168.055,364.358 158.698 C 357.949 155.424,357.600 154.740,356.310 142.963 C 348.787 74.271,298.519 19.071,231.111 5.484 C 211.022 1.434,199.003 0.685,185.185 2.619 M194.979 111.459 C 187.993 113.641,183.748 119.456,182.255 128.889 C 180.966 137.034,181.242 339.859,182.550 346.033 C 187.270 368.299,212.252 369.175,217.116 347.244 C 218.627 340.433,218.653 132.048,217.144 125.926 C 214.285 114.329,205.064 108.310,194.979 111.459 M148.063 147.643 C 141.755 150.004,138.112 154.479,136.194 162.222 C 134.484 169.129,134.729 307.047,136.462 312.640 C 142.485 332.080,165.957 331.275,170.228 311.481 C 173.479 296.410,173.035 170.109,169.692 159.172 C 166.833 149.816,156.696 144.413,148.063 147.643 M241.111 147.409 C 237.957 148.397,233.528 152.267,231.918 155.442 C 228.850 161.493,228.790 163.224,229.029 239.259 L 229.259 312.222 231.014 316.105 C 238.101 331.780,258.274 329.631,263.538 312.640 C 265.254 307.101,265.519 168.292,263.826 161.713 C 261.016 150.791,250.816 144.368,241.111 147.409 M99.301 195.002 C 90.658 199.572,89.647 203.934,89.647 236.667 C 89.647 264.281,89.979 267.536,93.353 272.994 C 100.077 283.875,117.635 281.851,122.911 269.586 C 127.156 259.718,127.187 213.453,122.955 203.882 C 118.790 194.463,107.988 190.408,99.301 195.002 M285.556 194.738 C 276.170 199.083,274.107 206.697,274.093 237.037 C 274.084 256.249,274.828 264.331,277.089 269.586 C 283.819 285.232,304.869 283.192,309.322 266.463 C 310.836 260.777,310.802 212.428,309.280 206.710 C 306.331 195.627,295.471 190.147,285.556 194.738 " stroke="none" fill="#000000" fill-rule="evenodd"/></g></svg>'
    }, {
        'nom' : 'music',
        'svg' : '<svg class="svg-inline--fa fa-music fa-w-16" aria-hidden="true" data-prefix="fas" data-icon="music" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" data-fa-i2svg=""><path fill="currentColor" d="M470.4 1.5l-304 96C153.1 101.7 144 114 144 128v264.6c-14.1-5.4-30.5-8.6-48-8.6-53 0-96 28.7-96 64s43 64 96 64 96-28.7 96-64V220.5l272-85.9v194c-14.1-5.4-30.5-8.6-48-8.6-53 0-96 28.7-96 64s43 64 96 64 96-28.7 96-64V32c0-21.7-21.1-37-41.6-30.5z"/></svg>'
    }, {
        'nom' : 'pause',
        'svg' : '<svg class="svg-inline--fa fa-pause fa-w-14 control-icon" aria-hidden="true" data-prefix="fas" data-icon="pause" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512" data-fa-i2svg=""><path fill="currentColor" d="M144 479H48c-26.5 0-48-21.5-48-48V79c0-26.5 21.5-48 48-48h96c26.5 0 48 21.5 48 48v352c0 26.5-21.5 48-48 48zm304-48V79c0-26.5-21.5-48-48-48h-96c-26.5 0-48 21.5-48 48v352c0 26.5 21.5 48 48 48h96c26.5 0 48-21.5 48-48z"/></svg>'
    }, {
        'nom' : 'play',
        'svg' : '<svg class="svg-inline--fa fa-play fa-w-14 control-icon" aria-hidden="true" data-prefix="fas" data-icon="play" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512" data-fa-i2svg=""><path fill="currentColor" d="M424.4 214.7L72.4 6.6C43.8-10.3 0 6.1 0 47.9V464c0 37.5 40.7 60.1 72.4 41.3l352-208c31.4-18.5 31.5-64.1 0-82.6z"/></svg>'
    }, {
        'nom' : 'random',
        'svg' : '<svg class="svg-inline--fa fa-random fa-w-16 control-icon" aria-hidden="true" data-prefix="fas" data-icon="random" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" data-fa-i2svg=""><path fill="currentColor" d="M504.971 359.029c9.373 9.373 9.373 24.569 0 33.941l-80 79.984c-15.01 15.01-40.971 4.49-40.971-16.971V416h-58.785a12.004 12.004 0 0 1-8.773-3.812l-70.556-75.596 53.333-57.143L352 336h32v-39.981c0-21.438 25.943-31.998 40.971-16.971l80 79.981zM12 176h84l52.781 56.551 53.333-57.143-70.556-75.596A11.999 11.999 0 0 0 122.785 96H12c-6.627 0-12 5.373-12 12v56c0 6.627 5.373 12 12 12zm372 0v39.984c0 21.46 25.961 31.98 40.971 16.971l80-79.984c9.373-9.373 9.373-24.569 0-33.941l-80-79.981C409.943 24.021 384 34.582 384 56.019V96h-58.785a12.004 12.004 0 0 0-8.773 3.812L96 336H12c-6.627 0-12 5.373-12 12v56c0 6.627 5.373 12 12 12h110.785c3.326 0 6.503-1.381 8.773-3.812L352 176h32z"/></svg>'
    }, {
        'nom' : 'repeat',
        'svg' : '<svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="repeat-alt" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" class="svg-inline--fa fa-repeat-alt fa-w-16 control-icon myicon fa-repeat"><path fill="currentColor" d="M493.544 181.463c11.956 22.605 18.655 48.4 18.452 75.75C511.339 345.365 438.56 416 350.404 416H192v47.495c0 22.475-26.177 32.268-40.971 17.475l-80-80c-9.372-9.373-9.372-24.569 0-33.941l80-80C166.138 271.92 192 282.686 192 304v48h158.875c52.812 0 96.575-42.182 97.12-94.992.155-15.045-3.17-29.312-9.218-42.046-4.362-9.185-2.421-20.124 4.8-27.284 4.745-4.706 8.641-8.555 11.876-11.786 11.368-11.352 30.579-8.631 38.091 5.571zM64.005 254.992c.545-52.81 44.308-94.992 97.12-94.992H320v47.505c0 22.374 26.121 32.312 40.971 17.465l80-80c9.372-9.373 9.372-24.569 0-33.941l-80-80C346.014 16.077 320 26.256 320 48.545V96H161.596C73.44 96 .661 166.635.005 254.788c-.204 27.35 6.495 53.145 18.452 75.75 7.512 14.202 26.723 16.923 38.091 5.57 3.235-3.231 7.13-7.08 11.876-11.786 7.22-7.16 9.162-18.098 4.8-27.284-6.049-12.735-9.374-27.001-9.219-42.046z" class=""/></svg>'
    }, {
        'nom' : 'repeat-1',
        'svg' : '<svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="repeat-1-alt" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" class="svg-inline--fa fa-repeat-1-alt fa-w-16 control-icon myicon fa-repeat-1"><path fill="currentColor" d="M493.544 181.463c11.956 22.605 18.655 48.4 18.452 75.75C511.339 345.365 438.56 416 350.404 416H192v47.495c0 22.475-26.177 32.268-40.971 17.475l-80-80c-9.372-9.373-9.372-24.569 0-33.941l80-80C166.138 271.92 192 282.686 192 304v48h158.875c52.812 0 96.575-42.182 97.12-94.992.155-15.045-3.17-29.312-9.218-42.046-4.362-9.185-2.421-20.124 4.8-27.284 4.745-4.706 8.641-8.555 11.876-11.786 11.368-11.352 30.579-8.631 38.091 5.571zM64.005 254.992c.545-52.81 44.308-94.992 97.12-94.992H320v47.505c0 22.374 26.121 32.312 40.971 17.465l80-80c9.372-9.373 9.372-24.569 0-33.941l-80-80C346.014 16.077 320 26.256 320 48.545V96H161.596C73.44 96 .661 166.635.005 254.788c-.204 27.35 6.495 53.145 18.452 75.75 7.512 14.202 26.723 16.923 38.091 5.57 3.235-3.231 7.13-7.08 11.876-11.786 7.22-7.16 9.162-18.098 4.8-27.284-6.049-12.735-9.374-27.001-9.219-42.046zm163.258 44.535c0-7.477 3.917-11.572 11.573-11.572h15.131v-39.878c0-5.163.534-10.503.534-10.503h-.356s-1.779 2.67-2.848 3.738c-4.451 4.273-10.504 4.451-15.666-1.068l-5.518-6.231c-5.342-5.341-4.984-11.216.534-16.379l21.72-19.939c4.449-4.095 8.366-5.697 14.42-5.697h12.105c7.656 0 11.749 3.916 11.749 11.572v84.384h15.488c7.655 0 11.572 4.094 11.572 11.572v8.901c0 7.477-3.917 11.572-11.572 11.572h-67.293c-7.656 0-11.573-4.095-11.573-11.572v-8.9z" class=""/></svg>'
    }, {
        'nom' : 'search',
        'svg' : '<svg class="svg-inline--fa fa-search fa-w-16" aria-hidden="true" data-prefix="fas" data-icon="search" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" data-fa-i2svg=""><path fill="currentColor" d="M505 442.7L405.3 343c-4.5-4.5-10.6-7-17-7H372c27.6-35.3 44-79.7 44-128C416 93.1 322.9 0 208 0S0 93.1 0 208s93.1 208 208 208c48.3 0 92.7-16.4 128-44v16.3c0 6.4 2.5 12.5 7 17l99.7 99.7c9.4 9.4 24.6 9.4 33.9 0l28.3-28.3c9.4-9.4 9.4-24.6.1-34zM208 336c-70.7 0-128-57.2-128-128 0-70.7 57.2-128 128-128 70.7 0 128 57.2 128 128 0 70.7-57.2 128-128 128z"/></svg>'
    }, {
        'nom' : 'step-backward',
        'svg' : '<svg class="svg-inline--fa fa-step-backward fa-w-14 control-icon" aria-hidden="true" data-prefix="fas" data-icon="step-backward" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512" data-fa-i2svg=""><path fill="currentColor" d="M64 468V44c0-6.6 5.4-12 12-12h48c6.6 0 12 5.4 12 12v176.4l195.5-181C352.1 22.3 384 36.6 384 64v384c0 27.4-31.9 41.7-52.5 24.6L136 292.7V468c0 6.6-5.4 12-12 12H76c-6.6 0-12-5.4-12-12z"/></svg>'
    }, {
        'nom' : 'step-forward',
        'svg' : '<svg class="svg-inline--fa fa-step-forward fa-w-14 control-icon" aria-hidden="true" data-prefix="fas" data-icon="step-forward" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512" data-fa-i2svg=""><path fill="currentColor" d="M384 44v424c0 6.6-5.4 12-12 12h-48c-6.6 0-12-5.4-12-12V291.6l-195.5 181C95.9 489.7 64 475.4 64 448V64c0-27.4 31.9-41.7 52.5-24.6L312 219.3V44c0-6.6 5.4-12 12-12h48c6.6 0 12 5.4 12 12z"/></svg>'
    }, {
        'nom' : 'user',
        'svg' : '<svg class="svg-inline--fa fa-user fa-w-14" aria-hidden="true" data-prefix="fas" data-icon="user" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512" data-fa-i2svg=""><path fill="currentColor" d="M224 256c70.7 0 128-57.3 128-128S294.7 0 224 0 96 57.3 96 128s57.3 128 128 128zm89.6 32h-16.7c-22.2 10.2-46.9 16-72.9 16s-50.6-5.8-72.9-16h-16.7C60.2 288 0 348.2 0 422.4V464c0 26.5 21.5 48 48 48h352c26.5 0 48-21.5 48-48v-41.6c0-74.2-60.2-134.4-134.4-134.4z"/></svg>'
    }, {
        'nom' : 'volume-down',
        'svg' : '<svg class="svg-inline--fa fa-volume-down fa-w-12 control-icon" aria-hidden="true" data-prefix="fas" data-icon="volume-down" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 384 512" data-fa-i2svg=""><path fill="currentColor" d="M256 88.017v335.964c0 21.438-25.943 31.998-40.971 16.971L126.059 352H24c-13.255 0-24-10.745-24-24V184c0-13.255 10.745-24 24-24h102.059l88.971-88.954c15.01-15.01 40.97-4.49 40.97 16.971zM384 256c0-33.717-17.186-64.35-45.972-81.944-15.079-9.214-34.775-4.463-43.992 10.616s-4.464 34.775 10.615 43.992C314.263 234.538 320 244.757 320 256a32.056 32.056 0 0 1-13.802 26.332c-14.524 10.069-18.136 30.006-8.067 44.53 10.07 14.525 30.008 18.136 44.53 8.067C368.546 316.983 384 287.478 384 256z"/></svg>'
    }, {
        'nom' : 'volume-mute',
        'svg' : '<svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="volume-mute" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" class="svg-inline--fa fa-volume-mute fa-w-16 control-icon myicon"><path fill="currentColor" d="M215.03 71.05L126.06 160H24c-13.26 0-24 10.74-24 24v144c0 13.25 10.74 24 24 24h102.06l88.97 88.95c15.03 15.03 40.97 4.47 40.97-16.97V88.02c0-21.46-25.96-31.98-40.97-16.97zM461.64 256l45.64-45.64c6.3-6.3 6.3-16.52 0-22.82l-22.82-22.82c-6.3-6.3-16.52-6.3-22.82 0L416 210.36l-45.64-45.64c-6.3-6.3-16.52-6.3-22.82 0l-22.82 22.82c-6.3 6.3-6.3 16.52 0 22.82L370.36 256l-45.63 45.63c-6.3 6.3-6.3 16.52 0 22.82l22.82 22.82c6.3 6.3 16.52 6.3 22.82 0L416 301.64l45.64 45.64c6.3 6.3 16.52 6.3 22.82 0l22.82-22.82c6.3-6.3 6.3-16.52 0-22.82L461.64 256z" class=""/></svg>'
    }, {
        'nom' : 'volume-off',
        'svg' : '<svg class="svg-inline--fa fa-volume-off fa-w-8 control-icon" aria-hidden="true" data-prefix="fas" data-icon="volume-off" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 256 512" data-fa-i2svg=""><path fill="currentColor" d="M256 88.017v335.964c0 21.438-25.943 31.998-40.971 16.971L126.059 352H24c-13.255 0-24-10.745-24-24V184c0-13.255 10.745-24 24-24h102.059l88.971-88.954c15.01-15.01 40.97-4.49 40.97 16.971z"/></svg>'
    }, {
        'nom' : 'volume-up',
        'svg' : '<svg class="svg-inline--fa fa-volume-up fa-w-18 control-icon" aria-hidden="true" data-prefix="fas" data-icon="volume-up" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 576 512" data-fa-i2svg=""><path fill="currentColor" d="M256 88.017v335.964c0 21.438-25.943 31.998-40.971 16.971L126.059 352H24c-13.255 0-24-10.745-24-24V184c0-13.255 10.745-24 24-24h102.059l88.971-88.954c15.01-15.01 40.97-4.49 40.97 16.971zm182.056-77.876C422.982.92 403.283 5.668 394.061 20.745c-9.221 15.077-4.473 34.774 10.604 43.995C468.967 104.063 512 174.983 512 256c0 73.431-36.077 142.292-96.507 184.206-14.522 10.072-18.129 30.01-8.057 44.532 10.076 14.528 30.016 18.126 44.531 8.057C529.633 438.927 576 350.406 576 256c0-103.244-54.579-194.877-137.944-245.859zM480 256c0-68.547-36.15-129.777-91.957-163.901-15.076-9.22-34.774-4.471-43.994 10.607-9.22 15.078-4.471 34.774 10.607 43.994C393.067 170.188 416 211.048 416 256c0 41.964-20.62 81.319-55.158 105.276-14.521 10.073-18.128 30.01-8.056 44.532 6.216 8.96 16.185 13.765 26.322 13.765a31.862 31.862 0 0 0 18.21-5.709C449.091 377.953 480 318.938 480 256zm-96 0c0-33.717-17.186-64.35-45.972-81.944-15.079-9.214-34.775-4.463-43.992 10.616s-4.464 34.775 10.615 43.992C314.263 234.538 320 244.757 320 256a32.056 32.056 0 0 1-13.802 26.332c-14.524 10.069-18.136 30.006-8.067 44.53 10.07 14.525 30.008 18.136 44.53 8.067C368.546 316.983 384 287.478 384 256z"/></svg>'
    }, {
        'nom' : 'volume',
        'svg' : '<svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="volume" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 480 512" class="svg-inline--fa fa-volume fa-w-15 control-icon myicon"><path fill="currentColor" d="M215.03 71.05L126.06 160H24c-13.26 0-24 10.74-24 24v144c0 13.25 10.74 24 24 24h102.06l88.97 88.95c15.03 15.03 40.97 4.47 40.97-16.97V88.02c0-21.46-25.96-31.98-40.97-16.97zM480 256c0-63.53-32.06-121.94-85.77-156.24-11.19-7.14-26.03-3.82-33.12 7.46s-3.78 26.21 7.41 33.36C408.27 165.97 432 209.11 432 256s-23.73 90.03-63.48 115.42c-11.19 7.14-14.5 22.07-7.41 33.36 6.51 10.36 21.12 15.14 33.12 7.46C447.94 377.94 480 319.53 480 256zm-141.77-76.87c-11.58-6.33-26.19-2.16-32.61 9.45-6.39 11.61-2.16 26.2 9.45 32.61C327.98 228.28 336 241.63 336 256c0 14.38-8.02 27.72-20.92 34.81-11.61 6.41-15.84 21-9.45 32.61 6.43 11.66 21.05 15.8 32.61 9.45 28.23-15.55 45.77-45 45.77-76.88s-17.54-61.32-45.78-76.86z" class=""/></svg>'
    }
]

function SvgReplaceWith(svgStr, iconClass) {
    let svg = $(svgStr).removeClass().addClass($('.myicon-' + iconClass).attr('class'));
    $(".myicon-" + iconClass).replaceWith(svg);
}

window.getSvg = (nom) => {
    let res = '';
    tabSvg.forEach(item => {
        if(item.nom == nom) {
            res += $(item.svg).removeClass().addClass('myicon-' + nom)[0].outerHTML;
        }
    });
    //console.log(res);
    return res;
}

window.SvgReplaceAll = () => {
    tabSvg.forEach(item => {
        SvgReplaceWith(item.svg, item.nom);
    });
}





// $(() => {
//     SvgReplaceWith(svgLogo, 'icon-logo');
//     SvgReplaceWith(svgRepeat, 'fa-repeat');
//     SvgReplaceWith(svgRepeat1, 'fa-repeat-1');
//     SvgReplaceWith(svgListMusic, 'fa-list-music');
//     SvgReplaceWith(svgVolume, 'fa-volume');
//     SvgReplaceWith(svgVolumeMute, 'fa-volume-mute');
// });

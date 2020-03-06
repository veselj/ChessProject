FROM php:7.4-cli

RUN apt-get update -y && \
    apt-get install -y zip unzip libzip-dev

RUN docker-php-ext-install -j$(nproc) zip

RUN curl -sS https://getcomposer.org/installer | php -- --install-dir=/usr/local/bin --filename=composer



.PHONY: run
run: prepare
	docker run -it --rm -v $(PWD):/usr/src/project -w /usr/src/project --entrypoint vendor/bin/phpunit swmsp-chessproject-php tests

.PHONY: prepare
prepare: build
	docker run -it --rm -v $(PWD):/usr/src/project -w /usr/src/project --entrypoint composer swmsp-chessproject-php install

.PHONY: build
build:
	docker build -t swmsp-chessproject-php .
